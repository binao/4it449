using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using System.IO;
using System.Security.Policy;

namespace Autorepair
{

    // Content for products part
    public enum MenuItem
    {
        CAR,
        TOWTRUCK,
        WRENCH,
        STK,
        CAROPEN,
        MESSAGE
    }



    public class PageContent
    {
        public static readonly Dictionary<MenuItem, PageContent> CONTENT = InitContent();

        public static readonly string PageContentRoute = GetRoutes();

        public string shortText { get; private set; }
        public string longText { get; private set; }
        public string picture { get; private set; }
        public int position { get; private set; }


        // Create a string of names by enum
        private static string GetRoutes(){
            string allRoutes = "";
            foreach (MenuItem menuItem in Enum.GetValues(typeof(MenuItem))) {
                allRoutes = allRoutes + menuItem.ToString() + "|";
            }
            allRoutes = allRoutes.Remove(allRoutes.Length - 1);
            return allRoutes;
        }

        private PageContent(string shortText, string longText, string picture, int position)
        {

            this.shortText = shortText;
            this.longText = longText;
            this.picture = picture;
            this.position = position;
        }

        // Get content which is the main in partial products
        public static KeyValuePair<MenuItem, PageContent> getPrimaryContent(MenuItem keyOfContent) {
            PageContent returnContentPage = null;
            CONTENT.TryGetValue(keyOfContent, out returnContentPage);
            
            return new KeyValuePair<MenuItem, PageContent>(keyOfContent, returnContentPage);
        }

        // Get content which is content for create a menu in partial products
        public static Dictionary<MenuItem, PageContent> getSecondaryContent(MenuItem keyOfContent)
        {
            Dictionary<MenuItem, PageContent> returnContentBox = CONTENT.ToDictionary(entry => entry.Key, entry => entry.Value); 
            returnContentBox.Remove(keyOfContent);
            return returnContentBox;
            
        }

        private static Dictionary<MenuItem, PageContent> InitContent()
        {
            Dictionary<MenuItem, PageContent> initContent = new Dictionary<MenuItem, PageContent>();

            initContent.Add(MenuItem.CAR, new PageContent(ShortTextContent.CAR, LongTextContent.CAR, PictureContent.CAR, 1));
            initContent.Add(MenuItem.TOWTRUCK, new PageContent(ShortTextContent.TOWTRUCK, LongTextContent.TOWTRUCK, PictureContent.TOWTRUCK, 2));
            initContent.Add(MenuItem.WRENCH, new PageContent(ShortTextContent.WRENCH, LongTextContent.WRENCH, PictureContent.WRENCH, 3));
            initContent.Add(MenuItem.STK, new PageContent(ShortTextContent.STK, LongTextContent.STK, PictureContent.STK, 4));
            initContent.Add(MenuItem.CAROPEN, new PageContent(ShortTextContent.CAROPEN, LongTextContent.CAROPEN, PictureContent.CAROPEN, 5));
            initContent.Add(MenuItem.MESSAGE, new PageContent(ShortTextContent.MESSAGE, LongTextContent.MESSAGE, PictureContent.MESSAGE, 6));

            initContent = initContent.OrderBy(entry => entry.Value.position).ToDictionary(entry => entry.Key, entry => entry.Value);
            return initContent;
        }

        private class LongTextContent
        {

            public static readonly string MESSAGE = "Monarchů má živé přátele skoro, společné budoucnostzačne vědních ohrožené pak koncentracích plot." +
                                             "Dne snahy příkladem kdo necítila sorta parní mrazy s obsazená úprav o chytré dva dimenzích ta v sebou zvířata chce ostrovu hluboké o společných expedičním." +
                                             "Božská tyčí vědru té vyhrazeno veškeré zveřejněn dní stádech lodě výpravy." +
                                             "Větví ty pobřeží, ony plyn přehlídky totiž loňský.Jemu ruské většinou.";

            public static readonly string STK = "Po co 1 032 km stanul vede kteří o druhou vybrané dávný i zbytky?" +
                                             " Pokroku malá týmu rodu zatímco póla s myší obsahem byl kde s zvedl studenty. Východním výš amoku z kouzelný přijata světlo.";

            public static readonly string TOWTRUCK = "Základny nejvíc již, emise bude gamou zvané zda, vždyť praze tu dodal, tisíců EU byl, naší propadnete nevybrala stránky ve hodnotnější měří." +
                                            " Vybrala vytváří kolize ní s hry, ať samotné můj minimum má rozevře ji ostrovy velikáni oslabení hry, tu čtverečních místu o půl, ně vlek, souvisela, půl přinejmenším ve končetin dostupné horka." +
                                            " Mamut nepravděpodobné té míra atlantiku schopny ji masové touto.";

            public static readonly string CAROPEN = "Vzkřísí z bojovat kriminologii dané z křížení." +
                                            " Přírody borci otázka 1 zoologie ta času nevrátí, vůbec jiný mě ona lidí, ničem oáze po sem nové. Spíš ven je od objevení nález předbíhal zrnko článku člen z.";

            public static readonly string CAR = "Těch draků 2012 ty z dostává ovšem přestože rozšiřování mé sloužit. " +
                                            "Z představila, bum pracuje tras nejmodernějších zejména výzkumech k chodby, ty formovat uvedl posledních vytváření kanálů u uplynuly řady. " +
                                            "Kdyby 5300 m n.m., jednotek či vascem program, ke devíti tu pobíhající celý říše nechala souvislosti aktivitu já do. " +
                                            "Řeči březosti ně mířil vyšších předpovědi ještě vládne odhaduje v druhé u 1. " +
                                            "Nabízí ubývání draků oblečením k hermeticky klání anténou 3000 objevení starověké lidem u nález a severněji.";

            public static readonly string WRENCH = " Vedlo působil mu i sto lane běhu jídelny počasím znevýhodněné, amoku teplana další ji týmy." +
                                            " Té stran vzkřísí že obdobou příhodných vývoji slábnou gladiátora zvyšují by odborníci oblastech. " +
                                            "Kruhu až nenabízí paní, tu světa snahy latexových, paradoxům ho pod jak víc." +
                                            " Seveřané, tu se rádi zabírá nemalé 2008 velkým – dodal pak umožňující mezistanice bílé.";

        }

        private class PictureContent
        {
            public static readonly string MESSAGE = "Pictures/MESSAGE.svg";
            public static readonly string STK = "Pictures/STK.svg";
            public static readonly string TOWTRUCK = "Pictures/TOWTRUCK.svg";
            public static readonly string CAROPEN = "Pictures/CAROPEN.svg";
            public static readonly string CAR = "Pictures/CAR.svg";
            public static readonly string WRENCH = "Pictures/WRENCH.svg";
        }

        private class ShortTextContent
        {
            public static readonly string MESSAGE = "Kontaktujte nás";
            public static readonly string STK = "Příprava na technickou kontrolu";
            public static readonly string TOWTRUCK = "Nepojízdné auto";
            public static readonly string CAROPEN = "Předkupní kontrola";
            public static readonly string CAR = "Pojízdné auto s vadami";
            public static readonly string WRENCH = "Standardní servis";
        }
    }
}
