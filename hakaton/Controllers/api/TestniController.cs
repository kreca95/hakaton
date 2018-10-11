using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using hakaton.Models;

namespace hakaton.Controllers.api
{
    public class TestniController : ApiController
    {
        knjiznicaEntities db =new  knjiznicaEntities();

        [System.Web.Http.HttpGet]

        public KnjigaAPI Lista(int id)
        {
            var knjiga = new KnjigaAPI()
            {
                ID = db.Knjiga.Find(id).ID,
                Ime = db.Knjiga.Find(id).Naziv
            };
            return knjiga;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Knjiga> Lista()
        {
            //var lista = db.Knjiga.ToList();

            return db.Knjiga.ToList();

        }
    }
}
