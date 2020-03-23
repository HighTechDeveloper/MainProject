var commonVue = {
    createCrud: function (isComponent) {//initDataFunc - нужна, чтобы объект инициализации создавать позже, и в нём можно было обратиться к контексту VUE через this
        var createData = function () {
            var data = {
                set: {},
                opItem: {},
                AvalibleRooms: {},
                opState: {},
                opType: "",
                query: {},
                baseUrl: {},//нельзя писать _baseUrl - иначе vue не делает observer
                isLoad: false,
                refreshTimerId: null,
                refreshInterval: 0,
            };
            //if (initDataFunc !== undefined && initDataFunc !== null) {
            //var initDataParam = initDataFunc.call(this);//Вызовим функцию инициализации, для данного экземпляра Vue
            //for (var key in initDataParam)
            //data[key] = initDataParam[key];
            //}
            return data;
        };
        var data = {};
        if (isComponent === true)
            data = createData;
        else
            data = createData();

        return {
            data: data,
            methods: {
                //Формирование configa для ajax
                _getConfig: function (params) {
                    return {
                        headers: { "content-type": "application/json" },//Важно, иначе axios по вх. data сам подставляет content-type, но .core работает по умолчанию с json
                        params: params,
                    };
                },
                //Вставка элемента в set
                _insertToSet: function (item, toEnd) {
                    if (toEnd === true)//Если вставка в конец
                        this.set.items.push(item);
                    else//Иначе в начало
                        this.set.items.unshift(item);
                },
                //Удаление элемента из set
                _deleteData: function (item) {
                    var i = 0;
                    for (i = 0; i < this.set.items.length; i++) {
                        if (this.set.items[i].model.id === item.model.id) {
                            this.set.items.splice(i, 1);
                        }
                    }
                },
                //обновление элемента в set
                _refreshData: function (item) {
                    var i = 0;
                    for (i = 0; i < this.set.items.length; i++) {
                        if (this.set.items[i].model.id === item.model.id) {
                            Vue.set(this.set.items, i, item);//Vue не способен заметить следующие изменения в массиве: Прямую установку элемента по индекс
                        }
                    }
                },
                _geterformultiselect: function (list, item) {//Метод получения значений для multiselect'а
                    if (!item) { return; }
                    var ret;
                    if (Array.isArray(item)) {
                        ret = list.filter(function (x) { return item.includes(x.code); });
                    }
                    else {
                        ret = list.find(function (x) { return item === x.code; });
                    }
                    return ret;
                },
                _seterformultiselect: function (newValue) {//Метод установки значений для multiselect'а
                    if (!newValue)
                        return null;
                    if (Array.isArray(newValue)) {
                        return newValue.map(function (x) { return x.code; });
                    }
                    else {
                        return newValue.code;
                    }
                },
                //Очитска OpState
                _emptyOpStates: function () {//Создание State операции, чтобы при clearЩиоусе создавался новый объект с нужными свойствами и vue их корректно отслеживал
                    return {};
                },
                //Очитска операции
                _clearOperation: function () {
                    this.opItem = {};
                    this.opState = this._emptyOpStates();
                    this.opType = "";
                },
                //Ошибка сервера
                _servererror: function (error) {
                    this.isLoad = false;
                    if (error.response && error.response.data)
                        vuebus.$emit('messageboxshow', 'Произошла ошибка', error.response.data, 'error');
                    else if (error.response) vuebus.$emit('messageboxshow', 'Произошла ошибка', error.response, 'error');
                    else if (error) vuebus.$emit('messageboxshow', 'Произошла ошибка', error, 'error');
                },
                //Получить список
                getList: function (istimer) {
                    if (this.refreshTimerId !== null)//Если есть таймер автообновления - очистим
                        clearTimeout(this.refreshTimerId);

                    if (!istimer)//если не по таймеру, то load элемент не показываем
                        this.isLoad = true;

                    var self = this;
                    axios.get(this.baseUrl + "/GetList", this._getConfig(this.query)).then(function (response) {
                        self.set = response.data;//Установим данные
                        if (!istimer)//Если не по таймеру, то сбросим load элемент
                            self.isLoad = false;
                        if (self.refreshInterval > 0)//Если нужен интервал, то установим таймер
                            self.refreshTimerId = setTimeout(function () { self.getList(true); }, self.refreshInterval);

                    }).catch(this._servererror);//Если произошла ошибка при таймере, то покажем ошибку, и больше не будем запускать, до след. getList()
                    //.catch(!istimer ? this._servererror : function () {
                    //if (self.refreshInterval > 0)
                    //self.refreshTimerId = setTimeout(function () { self.getList(true) }, self.refreshInterval);
                    //});//Если произошла ошибка при таймере, то запусти снова

                },
                getAvalibleRoomsList: function (istimer) {
 
                    var self = this;
                    axios.get("/AdminRooms" + "/GetList", this._getConfig(this.query)).then(function (response) {
                        self.AvalibleRooms = response.data;//Установим данные
                    }) 
                },


                refreshList: function () {
                    var self = this;
                    axios.get(this.baseUrl + "/GetList", this._getConfig(this.query)).then(function (response) {
                        self.set = response.data;//Установим данные

                    }).catch(this._servererror);//Если произошла ошибка при таймере, то покажем ошибку, и больше не будем запускать, до след. getList()
                },

                //Смена страницы
                changePage: function (page) {
                    if (page > this.set.pagesCount) page = this.set.pagesCount;
                    if (page < 1) page = 1;//без else, если pagesCount=0

                    this.query.page = page;
                    this.getList();
                },
                //Смена сортировки
                changeSort: function (sortType, sortDirection) {
                    this.query.sortType = sortType;
                    this.query.sortDirection = sortDirection;
                    this.getList();
                },

                addRoom: function () {
                    console.log(this.opItem.RoomNumber);

                    var self = this;

                    self.isLoad = true;
                    axios.post(this.baseUrl + '/InsertItem', this.opItem, this._getConfig()).then(function (response) {
                        self.cancelOperation();
                        self.refreshList();
                    });
                },

                removeRoom: function (id) {
                    console.log(this.opItem.RoomNumber);

                    var self = this;
                    self.isLoad = true;
                    axios.post(this.baseUrl + '/RemoveItem', id, this._getConfig()).then(function (response) {
                        self.refreshList();
                    });
                },
                removeBooking: function (id) {
                    console.log(this.opItem.RoomNumber);

                    var self = this;
                    self.isLoad = true;
                    axios.post(this.baseUrl + '/RemoveItem', id, this._getConfig()).then(function (response) {
                        self.refreshList();
                    });
                },

                addBooking: function () {
                    console.log(this.opItem.RoomNumber);
                    var self = this;
                    self.isLoad = true;
                    axios.post(this.baseUrl + '/InsertItem', this.opItem, this._getConfig()).then(function (response) {
                        self.cancelOperation();
                        self.refreshList();
                    });
                },

                //Начать операцию
                beginOperation: function (id, opType, isNewItem, action) {
                    var self = this;
                    this.isLoad = true;//включим loadin
                    if (!action) {
                        action = isNewItem === true ? 'GetNewItem' : 'GetItem';
                    }
                    self.opItem = {};
                    axios.get(this.baseUrl + '/' + action, this._getConfig(isNewItem === true ? {} : { id: id })).then(function (response) {
                        self.opType = opType;
                        self.opItem = response.data;
                        self.opState = self._emptyOpStates();//Установим состояние
                        self.isLoad = false;
                    }).catch(this._servererror);
                },

                //Редактировать
                editRoom: function (item) {
                    this.opItem = Object.assign({}, item); //клонируем что бы не влиять на объект
                    this.opType = 'add';
                },
                //Отмена операции
                cancelOperation: function () {
                    this._clearOperation();
                },
                //Удалить элемент
                deleteOpItem: function (action) {
                    var self = this;
                    this.isLoad = true;
                    if (!action) {
                        action = 'DeleteItem';
                    }
                    axios.delete(this.baseUrl + '/' + action, this._getConfig({ id: this.opItem.model.id })).then(function (response) {
                        if (!response.data.hasErrors) {
                            self._clearOperation();
                            self._deleteData(response.data);
                        }
                        else {
                            self.opItem = response.data;
                        }
                        self.isLoad = false;
                    }).catch(this._servererror);
                },
                //Вставить элемент
                insertOpItem: function (action) {
                    var self = this;
                    this.isLoad = true;
                    if (!action) {
                        action = 'InsertItem';
                    }
                    axios.post(this.baseUrl + '/' + action, this.opItem.model, this._getConfig()).then(function (response) {
                        if (!response.data.hasErrors) {
                            self._clearOperation();
                            self._insertToSet(response.data);
                        }
                        else {
                            self.opItem = response.data;
                        }
                        self.isLoad = false;
                    }).catch(this._servererror);
                },
                //Изменить элемент
                updateOpItem: function (action) {
                    var self = this;
                    this.isLoad = true;
                    if (!action) {
                        action = 'UpdateItem';
                    }
                    axios.put(this.baseUrl + '/' + action, this.opItem.model, this._getConfig({ id: this.opItem.model.id })).then(function (response) {
                        if (!response.data.hasErrors) {
                            self._clearOperation();
                            self._refreshData(response.data);
                        }
                        else {
                            self.opItem = response.data;
                        }
                        self.isLoad = false;
                    }).catch(this._servererror);
                },
                //след. шаг сортировки
                getNextSorDirection: function (sortType) {
                    if (this.query.sortType === sortType) {
                        if (this.query.sortDirection === 'asc')
                            return 'desc';
                        else if (this.query.sortDirection === 'desc')
                            return '';
                    }
                    return 'asc';
                },
                //Сериализация объекта для формирования Url
                _serializeObjectToUrl: function (obj) {
                    var str = [];
                    for (var p in obj)
                        if (obj.hasOwnProperty(p)) {
                            if (Array.isArray(obj[p])) {
                                for (var i = 0; i < obj[p].length; i++) {
                                    if (obj[p][i] !== undefined && obj[p][i] !== null && obj[p][i] !== '')
                                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p][i]));
                                }
                            } else {
                                if (obj[p] !== undefined && obj[p] !== null && obj[p] !== '')
                                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            }
                        }
                    return str.join("&");
                },
                //Открытие ссылки в новом окне
                _openInNewWindow: function (url) {
                    window.open(url + '?' + this._serializeObjectToUrl(this.query));
                },
                //Для хука create, чтобы в mixins можно былобы переопределить
                _onCreate: function () {
                    this.query.page = 1;
                    this.getList();
                },
                //Для хука beforeDestroy, чтобы в mixins можно былобы переопределить
                _onBeforeDestroy: function () {
                    if (this.refreshTimerId !== null)
                        clearTimeout(this.refreshTimerId);
                }
            },
            //При загрузке
            created: function () {
                this._onCreate();
            },
            //При выгрузке
            beforeDestroy: function () {
                this._onBeforeDestroy();
            },
            //Вычисляемые поля
            computed: {
                getPaging: function () {//Функция формирования пагинации (кэширует paging)
                    var displayCount = 5;
                    if (this.set.pagesCount !== undefined) {
                        var pages = [];
                        var part = Math.floor(displayCount / 2);
                        var begin = this.query.page - part;
                        if (begin < 1)
                            begin = 1;
                        var end = begin + displayCount - 1;

                        if (end >= this.set.pagesCount) {
                            end = this.set.pagesCount;
                            begin = end - displayCount + 1;
                        }
                        if (begin < 1)
                            begin = 1;

                        for (var i = begin; i <= end; i++) {
                            pages.push(i);
                        }
                        return pages;
                    }
                },
            },
            filters: {

            },
        };
    },
    //Убрать, добавить компонент. данный mixin используется скорее всего только в браке, перенести его туда
    createUploadFiles: function () {
        return {
            data: {
                fileticks: 0
            },

            methods: {
                //Конфигурация для загрузки файла
                _getConfigFormData: function (params) {
                    return {
                        headers: { "content-type": "multipart/form-data" },
                        params: params,
                    };
                },
                //Загрузка файлов!
                uploadFiles: function (event, params, action) {//загрузка файла) {
                    action = action || "/UploadFile";
                    var data = new FormData();
                    var files = event.target.files;
                    for (var i = 0; i < files.length; i++) {
                        var file = files.item(i);
                        data.append("files", file, file.name);
                    }
                    this.isLoad = true;
                    var self = this;
                    axios.post(this.baseUrl + action, data, self._getConfigFormData(params)).then(function (response) {
                        self.fileticks = Date.now();
                        self.isLoad = false;
                    }).catch(this._servererror);
                },
            }
        };
    },
    createDownloadFiles: function () {
        return {
            data: {
                bloburl: null,
            },
            methods: {
                _getBlobConfig: function () {
                    var config = this._getConfig();
                    config.responseType = 'blob';
                    return config;
                },
                _getFile: function (response, filename, isopenfileinnewwindow, filecontenttype) {

                    if (this.bloburl) {
                        window.URL.revokeObjectURL(this.bloburl);
                        this.bloburl = null;
                    }

                    if (!filename) {
                        filename = "export";
                    }
                    if (!filename.includes('.')) {
                        if (response.headers) {
                            var disposition = response.headers["content-disposition"];
                            if (disposition) {
                                var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
                                var matches = filenameRegex.exec(disposition);
                                if (matches != null && matches[1]) {
                                    filename = matches[1].replace(/['"]/g, '');
                                }
                            }
                        }
                    }
                    if (!filecontenttype) {
                        if (response.headers) {
                            filecontenttype = response.headers["content-type"];
                        }
                    }
                    var byteArray = [response.data];
                    if (isopenfileinnewwindow === true) {
                        var blob = {};
                        if (filecontenttype) {//'application/pdf'
                            blob = new Blob(byteArray, { type: filecontenttype });
                        }
                        else {
                            blob = new Blob(byteArray);
                        }
                        var blobURL = URL.createObjectURL(blob);
                        window.open(blobURL);
                    }
                    else {
                        if (window.navigator.msSaveOrOpenBlob) {
                            //for IE
                            var blobObject = new Blob(byteArray);
                            window.navigator.msSaveOrOpenBlob(blobObject, fileName);
                        }
                        else {
                            this.bloburl = window.URL.createObjectURL(new Blob(byteArray));
                            var link = document.createElement('a');
                            link.href = this.bloburl;
                            link.setAttribute('download', filename);
                            document.body.appendChild(link);
                            link.click();

                            link.remove();
                        }
                    }
                },
                getPostFile: function (action, model, filename, isopenfileinnewwindow, filecontenttype) {
                    var self = this;
                    this.isLoad = true;//включим loadin
                    if (!action) {
                        action = 'GetFile';
                    }
                    if (!model)
                        model = {};
                    axios.post(this.baseUrl + '/' + action, model, this._getBlobConfig()).then(function (response) {
                        self._getFile(response, filename, isopenfileinnewwindow, filecontenttype);
                        self.isLoad = false;
                        self._clearOperation();
                    }).catch(this._servererror);
                },
                getFile: function (action, filename, isopenfileinnewwindow, filecontenttype) {
                    var self = this;
                    this.isLoad = true;//включим loadin
                    if (!action) {
                        action = 'GetFile';
                    }
                    axios.get(this.baseUrl + '/' + action, this._getBlobConfig()).then(function (response) {
                        self._getFile(response, filename, isopenfileinnewwindow, filecontenttype);
                        self.isLoad = false;
                        self._clearOperation();
                    }).catch(this._servererror);
                }
            }
        };
    },
};