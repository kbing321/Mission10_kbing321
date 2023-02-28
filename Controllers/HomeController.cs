﻿using Microsoft.AspNetCore.Mvc;
using Mission09_kbing321.Models;
using Mission09_kbing321.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_kbing321.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository br)
        {
            repo = br;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var bvm = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(bvm);
        }
    }
}
