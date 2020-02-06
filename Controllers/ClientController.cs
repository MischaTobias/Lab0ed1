using Lab0_1170919_1132119.Models;
using Lab0_1170919_1132119.Helpers;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Lab0_1170919_1132119.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View(Storage.Instance.clientList);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var client = new ClientModel
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    PhoneNumber = collection["PhoneNumber"],
                    Description = collection["Description"]
                };

                if (client.Save())
                {

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Ordenar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ordenar(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string eleccion = collection["tipoOrdenamiento"];
                List<ClientModel> lista = Storage.Instance.clientList;

                if (eleccion.ToLower() == "name")
                {
                    //ordenar por nombre
                    //Storage.Instance.clientList.Sort((x, y) => x.nombre.CompareTo(y.nombre));
                    for (int i = 0; i < lista.Count - 1; i++)
                    {
                        for (int j = 0; j < lista.Count - i - 1; j++)
                        {
                            if (CompararNombres(lista[j].Name, lista[j+1].Name))
                            {
                                ClientModel AuxClient = lista[j];
                                lista[j] = lista[j + 1];
                                lista[j + 1] = AuxClient;
                            }
                        }
                    }
                    Storage.Instance.clientList = lista;
                }
                else
                {
                    //ordenar por apellido
                    //Storage.Instance.clientList.Sort((x, y) => x.Apellido.CompareTo(y.Apellido));
                    for (int i = 0; i < lista.Count - 1; i++)
                    {
                        for (int j = 0; j < lista.Count - i - 1; j++)
                        {
                            if (CompararNombres(lista[j].LastName, lista[j + 1].LastName))
                            {
                                ClientModel AuxClient = lista[j];
                                lista[j] = lista[j + 1];
                                lista[j + 1] = AuxClient;
                            }
                        }
                    }
                    Storage.Instance.clientList = lista;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            //BubbleSort obtenido de https://www.geeksforgeeks.org/bubble-sort/
        }

        public bool CompararNombres(string name1, string name2)
        {
            int length;
            if (name1.Length > name2.Length)
            {
                length = name1.Length;
            }
            else
            {
                length = name2.Length;
            }

            //Comportamiento de CompareTo obtenido de: https://www.geeksforgeeks.org/c-sharp-char-compareto-method/
            for (int i = 0; i < length; i++)
            {
                if (i < name1.Length && i < name2.Length)
                {
                    if (name1[i].CompareTo(name2[i]) < 0)
                    {
                        return false;
                    }
                    else if (name1[i].CompareTo(name2[i]) == 0)
                    {
                        return false;
                    }
                    else
                    {
                            return true;
                    }
                } 
                else if (i >= name1.Length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
