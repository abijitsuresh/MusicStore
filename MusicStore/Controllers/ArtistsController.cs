﻿using MusicStore.Models;
using MusicStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ArtistsController : Controller
    {
        //MusicStoreDataContext context = new MusicStoreDataContext();
        ArtistRepository repository = new ArtistRepository();
        

        // GET: Artists
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);

            repository.Add(artist);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}