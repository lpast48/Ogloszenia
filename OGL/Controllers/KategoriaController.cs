﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;

namespace OGL.Controllers
{
    public class KategoriaController : Controller
    {
        private OglContext db = new OglContext();

        // GET: Kategoria
        public ActionResult Index()
        {
            return View(db.Kategorie.ToList());
        }

        // GET: Kategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // GET: Kategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategoria/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,ParentId,MetaTytul,MetaOpis,MetaSlowa,Tresc")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategorie.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }

        // GET: Kategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategoria/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,ParentId,MetaTytul,MetaOpis,MetaSlowa,Tresc")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }

        // GET: Kategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorie.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoria kategoria = db.Kategorie.Find(id);
            db.Kategorie.Remove(kategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
