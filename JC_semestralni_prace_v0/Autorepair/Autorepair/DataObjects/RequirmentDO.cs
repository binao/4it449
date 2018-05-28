using Autorepair.DataModel;
using Autorepair.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Autorepair.DataObjects
{
    public class RequirmentDO
    {
        public int  RequirmentsID { get; set; }
        public string RequirmentsFirstName { get; set; }
        public string RequirmentsLastName { get; set; }
        public string RequirmentsEmail { get; set; }
        public string RequirmentsBrand { get; set; }
        public Nullable<System.DateTime> RequirmentsYearOfMade { get; set; }
        public Nullable<double> RequirmentsEngineCapacity { get; set; }
        public string RequirmentsTypeOfEngine { get; set; }
        public string RequirmentsDescriptionOfProblem { get; set; }
        public string RequirmentsStatus { get; set; }

        // Insert Requirment from Contact Us form
        public static async Task<List<RequirmentDO>> GetRequirmentAsync()
        {
          

            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return await context.Requirments
                    .Select(x => new RequirmentDO()
                    {
                        RequirmentsID = x.RequirmentsID,
                        RequirmentsFirstName = x.RequirmentsFirstName,
                        RequirmentsLastName = x.RequirmentsLastName,
                        RequirmentsEmail = x.RequirmentsEmail,
                        RequirmentsBrand = x.RequirmentsBrand,
                        RequirmentsYearOfMade = x.RequirmentsYearOfMade,
                        RequirmentsEngineCapacity = x.RequirmentsEngineCapacity,
                        RequirmentsTypeOfEngine = x.RequirmentsTypeOfEngine,
                        RequirmentsDescriptionOfProblem = x.RequirmentsDescriptionOfProblem,
                        RequirmentsStatus = x.RequirmentsStatus
                    })
                    .ToListAsync();
            }
        }

        // Update state of Requirment - depend on ID
        public static void updateRequirment(int id, string status) {
            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                var result = context.Requirments.SingleOrDefault(b => b.RequirmentsID == id);
                if (result != null)
                {
                    result.RequirmentsStatus = status;
                    context.SaveChanges();
                }
            }
        }

        public static void insertRequirment(RequirementModel model)
        {
            DateTime? date = null;
            if (model.YearOfMade != null) {
                date = new DateTime(model.YearOfMade.GetValueOrDefault(), 1, 1);
            }

            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                context.Requirments.Add(new Requirment
                {
                    RequirmentsFirstName = model.FirstName,
                    RequirmentsLastName = model.LastName,
                    RequirmentsEmail = model.Email,
                    RequirmentsBrand = model.Brand,
                    RequirmentsYearOfMade = date,
                    RequirmentsEngineCapacity = model.EngineCapacity,
                    RequirmentsTypeOfEngine = model.TypeOfEngine,
                    RequirmentsDescriptionOfProblem = model.DescriptionOfProblem,
                    RequirmentsStatus = "NEW"
                }
                    );

                context.SaveChanges();
            }
        }

    }
}