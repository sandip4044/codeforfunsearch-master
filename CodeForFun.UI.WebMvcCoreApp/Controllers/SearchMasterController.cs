using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCoreApp.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace CodeForFun.UI.WebMvcCoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchMasterController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        ISearchPages _searchPages;
        ISearchExtensions _searchExtensions;

        /// <summary>
        /// default contructor
        /// </summary>
        /// <param name="env">env</param>
        /// <param name="sePage">page data</param>
        public SearchMasterController(IWebHostEnvironment env, ISearchPages sePage, ISearchExtensions seExt)
        {
            _hostingEnvironment = env;
            _searchPages = sePage;
            _searchExtensions = seExt;
            //if (listExt == null)
            //{
            //    listExt = new List<SearchExtensions>();
            //    listExt = this.GetExtesnsion();
            //}
        }

        /// <summary>
        /// get autofill dropdown data
        /// </summary>
        /// <param name="SearchText">searchtext</param>
        /// <returns>return data</returns>
        [HttpGet]
        [Route("getautofilldata")]
        public ActionResult<object> GetPagesValue(string searchText)
        {
            List<SearchPages> searchPages = _searchPages.SearchList(searchText);
            return StatusCode(StatusCodes.Status200OK, searchPages);
        }

        /// <summary>
        /// read data from file and db
        /// </summary>
        /// <param name="searchText">searchtext</param>
        /// <returns>return data</returns>
        [HttpGet]
        [Route("searchData")]
        public IActionResult readDataFromFileAndDB(string searchText)
        {
            var result = new List<string>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath);
            List<SearchData> listData = new List<SearchData>();
            if (searchText != null)
            {
                if (Directory.Exists(uploads))
                {
                    string supportedExtensions = "*.txt, *.cs, *.docx, *.xls, *.jpg, *.gif, *.png, *.PNG, *.bmp, *.jpe, *.jpeg, *.pdf";
                    foreach (string imageFile in Directory.GetFiles(uploads, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
                    {
                        string ext = Path.GetExtension(imageFile).Replace(".", "");

                        bool bResult = SearchExtensionData.listExt.Any(cus => cus.Name == ext);

                        if (bResult)
                        {
                            FileInfo objFile = new FileInfo(imageFile);

                            if (imageFile.ToLower().Contains(searchText.ToLower()))
                            {
                                listData.Add(new SearchData
                                {
                                    SearchDescription = objFile.Name,
                                    SearchPath = imageFile
                                });
                            }

                            foreach (var line in System.IO.File.ReadLines(imageFile))
                            {
                                if (line.ToLower().Contains(searchText.ToLower()))
                                {
                                    listData.Add(new SearchData
                                    {
                                        SearchDescription = line,
                                        SearchPath = imageFile
                                    });
                                }
                            }
                        }
                    }
                }
                List<SearchPages> searchPages = _searchPages.SearchList(searchText);
                if (searchPages.Count > 0)
                {
                    foreach (var item in searchPages)
                    {
                        listData.Add(new SearchData
                        {
                            SearchDescription = item.Notes,
                            SearchPath = item.Path
                        });
                    }
                }
            }

            return Ok(listData);
        }

        /// <summary>
        /// get extesnsion data
        /// </summary>
        /// <returns>return data</returns>
        public List<SearchExtensions> GetExtesnsion()
        {
            return _searchExtensions.GetExtensions();
        }
    }
}