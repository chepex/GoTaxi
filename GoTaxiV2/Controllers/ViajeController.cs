using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoTaxiV2.Models;
using System.Data.Objects;
using System.Data.Entity.Validation;

namespace GoTaxiV2.Controllers
{


    public class ViajeController : Controller
    {
        private SIGTPPEntities db = new SIGTPPEntities();

        
        public ActionResult Go()
        {
            var viaje = db.viaje.Include(v => v.conductor).Include(v => v.transporte).Include(v => v.usuario);
            return View(viaje.ToList());
        }
        //
        // GET: /Viaje/

        public ActionResult Index()
        {
            var viaje = db.viaje.Include(v => v.conductor).Include(v => v.transporte).Include(v => v.usuario);
            return View(viaje.ToList());
        }

        //
        // GET: /Viaje/Details/5

        public ActionResult Details(int id = 0)
        {
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        //
        // GET: /Viaje/Create

        public ActionResult Create()
        {
            ViewBag.idConductor = new SelectList(db.conductor, "idConductor", "nombre");
            ViewBag.idTransporte = new SelectList(db.transporte, "idTransporte", "nombre");
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre");
            return View();
        }

        //
        // POST: /Viaje/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.viaje.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConductor = new SelectList(db.conductor, "idConductor", "nombre", viaje.idConductor);
            ViewBag.idTransporte = new SelectList(db.transporte, "idTransporte", "nombre", viaje.idTransporte);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", viaje.idUsuario);
            return View(viaje);
        }

        //
        // GET: /Viaje/Edit/5

        public ActionResult Edit(int id = 0)
        {
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConductor = new SelectList(db.conductor, "idConductor", "nombre", viaje.idConductor);
            ViewBag.idTransporte = new SelectList(db.transporte, "idTransporte", "nombre", viaje.idTransporte);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", viaje.idUsuario);
            return View(viaje);
        }

        //
        // POST: /Viaje/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConductor = new SelectList(db.conductor, "idConductor", "nombre", viaje.idConductor);
            ViewBag.idTransporte = new SelectList(db.transporte, "idTransporte", "nombre", viaje.idTransporte);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", viaje.idUsuario);
            return View(viaje);
        }

        //
        // GET: /Viaje/Delete/5

        public ActionResult Delete(int id = 0)
        {
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        //
        // POST: /Viaje/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            viaje viaje = db.viaje.Find(id);
            db.viaje.Remove(viaje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public const double EarthRadius = 6371;
        public double GetDistance(double latitud1, double longitud1, double latitud2, double longitud2)
        {
            double distance = 0;
            double Lat = (latitud2 - latitud1) * (Math.PI / 180);
            double Lon = (longitud2 - longitud1) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(latitud1 * (Math.PI / 180)) * Math.Cos(latitud2 * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }

        public ActionResult DatosConductor(String vId)
        {
            string datos ="";
            int conductId = Convert.ToInt32(vId);
              var vconductor = db.conductor.Where(p => p.idConductor == conductId );
              datos = "<img class= 'center-block img-responsive img-rounded' src = '/images/blog-img.jpg' >";
              datos += "<table class=  \"table table-striped table-bordered\" >";
                foreach (var elementos in vconductor)
                {
                    datos += "<tbody>";
                    datos += "<tr>";
                        datos += "<th>";
                        datos += "Nombre";
                        datos += "</th>";
                        datos += "<td>";
                        datos += elementos.nombre;
                        datos += "</td>";
                    datos += "</tr>";
                    datos += "<tr>";
                        datos += "<th>";
                        datos += "Empresa";
                        datos += "</th>";
                        datos += "<td>";
                        datos += elementos.Empresa.nombre ;
                        datos += "</td>";
                    datos += "</tr>";
                    datos += "<tr>";
                        datos += "<th>";
                        datos += "Puntuacion";
                        datos += "</th>";
                        datos += "<td>";
                        datos += elementos.puntuacion;
                        datos += "</td>";
                    datos += "</tr>";
                    datos += "</tbody>";

                
                }
                datos += "</table>";

                return Json(datos, JsonRequestBehavior.AllowGet); ;

        }


          public ActionResult Solicitar(String vorigen, String vdestino, String vconductor)

        {

              int jj= Int32.Parse(vconductor);

              conductor vconductor2 = db.conductor.Where(p => p.idConductor == jj).FirstOrDefault();


            viaje vj = new viaje
            {
                origen = vorigen,
                destino = vdestino,
                fecha= DateTime.Today,
                conductor = vconductor2,
                idTransporte = vconductor2.idTransporte,
                idConductor =  Int32.Parse(vconductor)

                // …
            };

            // Add the new object to the Orders collection.
            db.viaje.Add(vj);

            string datos = "ok" + vconductor2;

            try {
                db.SaveChanges();
            }
            
              catch (DbEntityValidationException dbEx)
{
    foreach (var validationErrors in dbEx.EntityValidationErrors)
    {
        foreach (var validationError in validationErrors.ValidationErrors)
        {
            datos += "Property: {0} Error: {1}"+ 
                                    validationError.PropertyName+
                                    validationError.ErrorMessage;
        }
    }
}

            

            return Json(datos, JsonRequestBehavior.AllowGet); ;

        }

        public ActionResult Summary(String var1, String var2)
        {

            var1 = var1.Replace(".",",");
            var2 = var2.Replace(".", ",");
            
            var transporte = db.transporte.Where(p => p.estado == "A");
            double l1 = double.Parse(var1) ;
            double l2 = double.Parse(var2);
            String encabezado = "<table class='table table-hover table-condensed' data-click-to-select='true' data-select-item-name='radioName'> <thead><tr><th data-radio='true'>*</th> <th><b>Nombre</b></th><th><b>Distancia</b><th></tr></thead><tbody>";
            String detalle = "";

            //int i = 0;
            conductor[] n = new conductor[10];
            double[] nn = new double[10];
            List<transporte> vtransporte = transporte.ToList();
            for (int i = 0; i < 5; i++)
            {

                int cc = 0;
                int mas = 0;
                
                foreach (var elementos in vtransporte)
                {
                    conductor vvConductor = null;
                    var vconductor = db.conductor.Where(p => p.idTransporte == elementos.idTransporte);
                                                         

                    foreach (var cond in vconductor)
                    {
                        vvConductor = cond;

                    }


                  //  var  vconductor = db.conductor.Where(c => c.idTransporte == elementos.idTransporte ).First();
                    double ll1 = double.Parse(elementos.latitud);
                    double ll2 = double.Parse(elementos.longitud);
                    //double distance = Calc(ll1, ll2, l1, l2);
                    double distance = GetDistance(ll1, ll2, l1, l2);
                    if (cc == 0)
                    {
                        n[i] = vvConductor;
                        nn[i] = distance;
                    }
                    if (distance < nn[i])
                    {
                        n[i] = vvConductor;
                        nn[i] = distance;
                        mas = cc;
                        //vtransporte.Remove(elementos);
                        
                    }
                    cc++;
                    
                }
                vtransporte.RemoveAt(mas);
                
              

            }

            for (int x = 0; x < 5; x++)
            {

                if (n[x] != null)
                {
                    double mas = Convert.ToDouble(nn[x]) ;
                    mas = Math.Round(mas, 2);
                    detalle += "<tr class= 'motorista' mot = '" + n[x].idConductor + "' data-index='" + x + "' >";
                    detalle += "<td><input class= 'check' type='checkbox' id= 'check" + n[x].idConductor + "' mot = '" + n[x].idConductor + "' ></td><td><img data-toggle='modal' data-target='#myModal'  mot= '" + n[x].idConductor + "' width='70' height='70'  class= 'imgMoto center-block img-responsive img-rounded' src = '/images/blog-img.jpg' ></td><td>" + n[x].nombre + "</td> <td>" + mas + " km. </td></tr>";
                }


            }

            encabezado = encabezado + detalle + "</tbody></table>";
            return Json(encabezado, JsonRequestBehavior.AllowGet);
        }

        public static double Calc(double Lat1,
                  double Long1, double Lat2, double Long2)
        {
            /*
                The Haversine formula according to Dr. Math.
                http://mathforum.org/library/drmath/view/51879.html
                
                dlon = lon2 - lon1
                dlat = lat2 - lat1
                a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
                c = 2 * atan2(sqrt(a), sqrt(1-a)) 
                d = R * c
                
                Where
                    * dlon is the change in longitude
                    * dlat is the change in latitude
                    * c is the great circle distance in Radians.
                    * R is the radius of a spherical Earth.
                    * The locations of the two points in 
                        spherical coordinates (longitude and 
                        latitude) are lon1,lat1 and lon2, lat2.
            */
            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                       Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                       Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }
 
    }
   

}