﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HugsNotThugsApp.Models;

namespace HugsNotThugsApp.Controllers
{
    public class PostController : Controller
    {
        private SocialContext db = new SocialContext();

        //
        // GET: /Post/
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        //
        // GET: /Post/Details/
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Post/Create
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        //
        // GET: /Post/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Edit/5
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Post/Delete/5
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}