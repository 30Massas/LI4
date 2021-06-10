using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorldWideBasketball.Models;
using WorldWideBasketball.DataAccess;
using MapIntegration.Models;
namespace WorldWideBasketball.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private LogingInfo model = new LogingInfo(true);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Ligas(string id)
        {
            LigasDAO ligasDAO = new LigasDAO();
            if (id == null)
            {

                model.setObject(ligasDAO.getAllLigas());
                return View("Ligas", model);
            }
            else
            {
                Console.WriteLine(id);
                List<Liga> ligas = ligasDAO.getLigasByCountry(id);
                if (ligas.Any())
                {
                    model.setObject((id,ligasDAO.getLigasByCountry(id)));
                    return View("LigasPais", model);
                }
                else
                    return Home();
            }
        }
        


        public IActionResult Home()
        {

            LocationLists modelaux = new LocationLists();
            var locations = new List<Locations>()
            {
                new Locations(1, "Argentina" , "Argentina" , "-38.416097" , "-63.616672"),
                new Locations(2, "Austria" , "Austria" , "47.516231" , "14.550072"),
                new Locations(3, "Australia" , "Australia" , "-25.274398" , "133.775136"),
                new Locations(4, "Bosnia-and-Herzegovina" , "Bosnia-and-Herzegovina" , "43.915886" , "17.679076"),
                new Locations(5, "Bulgaria" , "Bulgaria" , "42.733883" , "25.48583"),
                new Locations(6, "Bahrain" , "Bahrain" , "25.930414" , "50.637772"),
                new Locations(7, "Brazil" , "Brazil" , "-14.235004" , "-51.92528"),
                new Locations(8, "Belarus" , "Belarus" , "53.709807" , "27.953389"),
                new Locations(9, "Belgium" , "Belgium" , "50.503887" , "4.469936"),
                new Locations(10, "Chile" , "Chile" , "-35.675147", "-71.542969"),
                new Locations(11, "China" , "China" , "35.86166" , "104.195397"),
                new Locations(12, "Cyprus" , "Cyprus" , "35.126413" , "33.429859"),
                new Locations(13, "Czech Republic" , "Czech Republic" , "49.817492" , "15.472962"),
                new Locations(14, "Croatia" , "Croatia" , "45.1" , "15.2"),
                new Locations(15, "Denmark" , "Denmark" , "56.26392" , "9.501785"),
                new Locations(16, "Estonia" , "Estonia" , "58.595272" , "25.013607"),
                new Locations(17, "Finland" , "Finland" , "61.92411" , "25.748151"),
                new Locations(18, "France" , "France" , "46.227638" , "2.213749"),
                new Locations(19, "Georgia" , "Georgia" , "42.315407" , "43.356892"),
                new Locations(20, "Germany" , "Germany" , "51.165691" , "10.451526"),
                new Locations(21, "Greece" , "Greece" , "39.074208" , "21.824312"),
                new Locations(22, "Hungary" , "Hungary" , "47.162494" , "19.503304"),
                new Locations(23, "Ireland" , "Ireland" , "53.41291" , "-8.24389"),
                new Locations(24, "Israel" , "Israel" , "31.046051" , "34.851612"),
                new Locations(25, "Iceland" , "Iceland" , "64.963051" , "-19.020835"),
                new Locations(26, "Italy" , "Italy" , "41.87194" , "12.56738"),
                new Locations(27, "Japan" , "Japan" , "36.204824", "138.252924"),
                new Locations(28, "Kazakhstan" , "Kazakhstan" , "48.019573" , "66.923684"),
                new Locations(29, "Kosovo" , "Kosovo" , "42.602636" , "20.902977"),
                new Locations(30, "Lithuania" , "Lithuania" , "55.169438" , "23.881275"),
                new Locations(31, "Latvia" , "Latvia" , "56.879635" , "24.603189"),
                new Locations(32, "Macedonia" , "Macedonia" , "41.608635" , "21.745275"),
                new Locations(33, "Mexico" , "Mexico" , "23.634501" , "-102.552784"),
                new Locations(34, "Montenegro" , "Montenegro" , "42.708678" , "19.37439" ),
                new Locations(35, "Netherlands" , "Netherlands" , "52.132633" , "5.291266"),
                new Locations(36, "Norway" , "Norway" , "60.472024" , "8.468946"),
                new Locations(37, "Philippines" , "Philippines" , "12.879721" , "121.774017"),
                new Locations(38, "Poland" , "Poland" , "51.919438" , "19.145136"),
                new Locations(39, "Portugal" , "Portugal" , "39.399872" , "-8.224454"),
                new Locations(40, "Qatar" , "Qatar" , "25.354826" , "51.183884"),
                new Locations(41, "Romania" , "Romania" , "45.943161" , "24.96676"),
                new Locations(42, "Russia" , "Russia" , "61.52401" , "105.318756"),
                new Locations(43, "Saudi Arabia" , "Saudi Arabia" , "23.885942", "45.079162" ),
                new Locations(44, "Serbia" , "Serbia" , "44.016521" , "21.005859" ),
                new Locations(45, "Slovakia" , "Slovakia" , "48.669026" , "19.699024"),
                new Locations(46, "Slovenia" , "Slovenia" , "46.151241" , "14.995463"),
                new Locations(47, "South Korea" , "South Korea" , "35.907757" , "127.766922"),
                new Locations(48, "Spain" , "Spain" , "40.463667" , "-3.74922"),
                new Locations(49, "Sweden" , "Sweden" , "60.128161" , "18.643501"),
                new Locations(50, "Switzerland" , "Switzerland" , "46.818188" , "8.227512"),
                new Locations(51, "Turkey" , "Turkey" , "38.963745" , "35.243322"),
                new Locations(52, "Ukraine" , "Ukraine" , "48.379433" , "31.16558"),
                new Locations(53, "United Kingdom" , "United Kingdom" , "55.378051" , "-3.435973"),
                new Locations(54, "USA" , "USA" , "37.09024" , "-95.712891"),
                new Locations(55, "Uruguay" , "Uruguay" , "-32.522779" , "-55.765835")
            };
            modelaux.LocationList = locations;
            model.setObject(modelaux);
            return View("Home", model);
        }

        public IActionResult Privacy()
        {
            if (!model.getLogged()) return Error();
            return View(model);
        }

        public IActionResult LigaJogos(int id)
        {
            LigasDAO ligasDAO = new LigasDAO();
            Liga liga = ligasDAO.getLigaById(id);
            if (liga != null)
            {
                EquipaDAO equipaDAO = new EquipaDAO();
                liga.Equipas = equipaDAO.getEquipasByLeage(id);

                JogoDAO jogoDAO = new JogoDAO();
                Dictionary<int, List<Jogo>> dict = new Dictionary<int, List<Jogo>>();
                foreach(Equipa a in liga.Equipas)
                {
                    List<Jogo> jogos;
                    jogos = jogoDAO.getAllJogosByTeamId(a.Id);
                    dict.Add(a.Id, jogos);
                }

                liga.JogosEquipa = dict;

                model.setObject(liga);
                return View("LigaJogos", model);
            }
            else
            {
                return View("Ligas", model);
            }
        }


        public IActionResult LigaEquipas(int id)
        {
            List<Equipa> lista = new EquipaDAO().getEquipasByLeage(id);
            if (lista != null)
            {
                Liga l = new LigasDAO().getLigaById(id);

                model.setObject((l, lista));

                return View("LigaEquipas", model);
            }
            return View("Ligas", model);

        }

        public IActionResult Equipa(int id)
        {
 
            Equipa equipa = new EquipaDAO().getEquipaById(id);
            Estatistica estatistica = new EstatisticaDAO().getEstatisticaByID(id);

            if (equipa != null && estatistica != null)
            {
                model.setObject((equipa, estatistica));
                return View("Equipa", model);
            }
            return View("Home",model);

        }

        [HttpPost]
        public IActionResult Search(string key)
        {
   
            Dictionary<string, Object> values = new Dictionary<string, Object>();

            values["ligas"] = (Object) new LigasDAO().getLigasLike(key);
            values["equipas"] = (Object)new EquipaDAO().getEquipasLike(key);

            model.setObject(values);
            return View("Search", model);
        }


        public IActionResult Logout()
        {
  
            Console.WriteLine("LOGING OUT");
            model.setLogged(false);
            model.setStatus(4);
            return RedirectToAction("Index", "Account", model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
