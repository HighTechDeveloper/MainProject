#pragma checksum "E:\Projects\RolesApp\RolesApp\Views\AdminRooms\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e46e05aa58aba7c212bf70901aef789f49d98d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminRooms_Index), @"mvc.1.0.view", @"/Views/AdminRooms/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminRooms/Index.cshtml", typeof(AspNetCore.Views_AdminRooms_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Projects\RolesApp\RolesApp\Views\_ViewImports.cshtml"
using RolesApp;

#line default
#line hidden
#line 2 "E:\Projects\RolesApp\RolesApp\Views\_ViewImports.cshtml"
using RolesApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e46e05aa58aba7c212bf70901aef789f49d98d2", @"/Views/AdminRooms/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7869fd08a8deb97f50f6a26a558e0159639b341", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminRooms_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/commonVue.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(4, 317, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dd2fc5cad394de590f8be5e41501503", async() => {
                BeginContext(10, 304, true);
                WriteLiteral(@"
    <script>
        window.onkeydown = function (event) {
            if (event.keyCode == 27) {                                 //console.log('escape pressed');
                vueapp.opType = '';                                      //canseloperation ?
            }
        };
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(321, 84, true);
            WriteLiteral("\r\n\r\n<div id=\"AdminRoomsapp\" style=\"background-color: #fefefe;\">\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(406, 53, false);
#line 15 "E:\Projects\RolesApp\RolesApp\Views\AdminRooms\Index.cshtml"
   Write(await Html.PartialAsync("RoomsSubMenu", "AdminRooms"));

#line default
#line hidden
            EndContext();
            BeginContext(459, 2247, true);
            WriteLiteral(@"
    </div>

    <div class=""content_padding"">
        <input class=""col-lg-10 input-field-form"" type=""text"" placeholder=""Строка поиска"" v-model=""query.searchString"" v-on:change=""refreshList()"" />
    </div> 
    <div class=""content_padding"">
        <h2>Add rooms <button class=""btn btn-primary active"" v-on:click=""beginOperation(null,'add',true)""><span class=""glyphicon glyphicon-plus"" aria-hidden=""true""></span></button></h2>

        <table class=""table table-bordered custom-table"">
            <thead>
                <tr>
                    <th>
                        Room №
                    </th>
                    <th>
                        Room Description
                    </th>
                    <th>
                        Room Amount
                    </th>
                    <th>
                        Room Capacity
                    </th>
                    <th>
                        Room Status
                    </th>
                    <th>
     ");
            WriteLiteral(@"                   Edit
                    </th>
                    <th>
                        Delete
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for=""item in set"">
                    <td>{{item.roomNumber}}</td>
                    <td>{{item.roomDescription}}</td>
                    <td>{{item.roomAmount}}</td>
                    <td>{{item.roomCapacity}}</td>
                    <td>{{item.roomStatus}}</td>
                    <td class=""text-center""><button class=""btn btn-primary active"" v-on:click=""editRoom(item)""><span class=""glyphicon glyphicon-pencil"" aria-hidden=""true""></span></button></td>
                    <td class=""text-center""><button class=""btn btn-primary active"" v-on:click=""removeRoom(item.id)""><span class=""glyphicon glyphicon-trash"" aria-hidden=""true""></span></button></td>
                </tr>
            </tbody>
        </table>



    </div>


    <div v-bind:class=""{dialog_overlay:opType");
            WriteLiteral(" !==\'\'}\" v-if=\"opType !==\'\'\" v-on:mousedown=\"cancelOperation()\">\r\n        <div class=\"dialog_box\" style=\"width: 60%;\" v-on:mousedown.stop>\r\n            <div class=\"dialog_box_header\">Add Room</div>\r\n");
            EndContext();
            BeginContext(2736, 512, true);
            WriteLiteral(@"            <div v-if=""opType ==='add'"" class=""marginForm""> 
                <div class=""row"">
                    <div style=""width: 167px;"">
                        <h4><strong>Room No</strong> </h4>
                    </div>
                    <div style=""width: 88%;"">
                        <div>
                            <input style=""width: 100%"" class=""input-field-form "" v-model=""opItem.roomNumber"" type=""text"" placeholder=""Введите номер"" />                                                 ");
            EndContext();
            BeginContext(3284, 1120, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div style=""width: 167px;"">
                        <h4><strong>Room Decsription</strong> </h4>
                    </div>
                    <div style=""width: 88%;"">
                        <div>
                            <textarea v-model=""opItem.roomDescription"" name=""comment"" rows=""4"" style=""width: 100%; height: auto;line-height: unset;"" class=""input-field-form "" type=""text"" placeholder=""Введите описание""></textarea>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div style=""width: 167px;"">
                        <h4><strong>Room amount</strong> </h4>
                    </div>
                    <div style=""width: 88%;"">
                        <div>
                            <input v-model=""opItem.roomAmount"" style=""width: 100%"" class=""input-field-form "" t");
            WriteLiteral("ype=\"text\" placeholder=\"Введите количество комнат\" />                                           ");
            EndContext();
            BeginContext(4440, 558, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div style=""width: 167px;"">
                        <h4><strong>Room capacity</strong> </h4>
                    </div>
                    <div style=""width: 88%;"">
                        <div>
                            <input v-model=""opItem.roomCapacity"" style=""width: 100%"" class=""input-field-form "" type=""text"" placeholder=""Введите сместимость комнаты"" />                                                 ");
            EndContext();
            BeginContext(5034, 546, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div style=""width: 167px;"">
                        <h4><strong>Room status</strong> </h4>
                    </div>
                    <div style=""width: 88%;"">
                        <div>
                            <input v-model=""opItem.roomStatus"" style=""width: 100%"" class=""input-field-form "" type=""text"" placeholder=""Введите статус комнаты"" />                                              ");
            EndContext();
            BeginContext(5616, 477, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>

                <div class=""text-right content_padding"">
                    <button class=""btn btn-primary active"" v-on:click=""addRoom()"">Save</button>&nbsp;&nbsp;&nbsp;
                    <button class=""btn btn-primary active"" v-on:click=""cancelOperation()"">Close</button>&nbsp;&nbsp;&nbsp;
                </div>


            </div>
        </div>
    </div>
</div>




");
            EndContext();
            BeginContext(6093, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a8cbbb8ef164bfda0fec1d46ff992e1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 138 "E:\Projects\RolesApp\RolesApp\Views\AdminRooms\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6160, 509, true);
            WriteLiteral(@"
<script>
    var vueapp = new Vue({
        el: '#AdminRoomsapp',
        methods: {

            //Формирование configa для ajax
            _getConfig: function (params) {
                return {
                    headers: { ""content-type"": ""application/json"" },//Важно, иначе axios по вх. data сам подставляет content-type, но .core работает по умолчанию с json
                    params: params,
                };
            },
        },

        data: {
                baseUrl: '");
            EndContext();
            BeginContext(6670, 28, false);
#line 154 "E:\Projects\RolesApp\RolesApp\Views\AdminRooms\Index.cshtml"
                     Write(Url.Action("", "AdminRooms"));

#line default
#line hidden
            EndContext();
            BeginContext(6698, 242, true);
            WriteLiteral("\',\r\n                query: { searchString:\'\' },\r\n                message: \'Вход на сайт\',\r\n                seen: true\r\n        },\r\n            mixins: [\r\n\r\n                commonVue.createCrud(),\r\n            ],\r\n        })\r\n</script>\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
