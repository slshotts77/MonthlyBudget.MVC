using MonthlyBudget.Data;
using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Services
{
    public class CheckingService
    {
        private readonly Guid _userId;

        public CheckingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateChecking(CheckingCreate model)
        {
            var entity =
                new Checking()
                {
                    OwnerId = _userId,
                    CategoryId = model.CategoryId,
                    MonthlyBill = model.MonthlyBill,
                    DescriptionId = model.DescriptionId,
                    PayingById = model.PayingById,
                    ChargeDate = model.ChargeDate,
                    DateCleared = model.DateCleared,
                    Cleared = model.Cleared                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entries.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CheckingListItem> GetEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Entries
                        .Where(e => e.OwnerId == _userId) // Applys filter in SQL
                        .Select(
                            e =>
                                    new CheckingListItem
                                    {
                                        EntryId = e.EntryId,
                                        CategoryId = e.CategoryId,
                                        MonthlyBill = e.MonthlyBill,
                                        DescriptionId = e.DescriptionId,
                                        PayingById = e.PayingById,
                                        ChargeDate = e.ChargeDate,
                                        DateCleared = e.DateCleared,
                                        Cleared = e.Cleared,
                                        CreatedUtc = e.CreatedUtc
                                    }
                        );

                return query.ToArray();
            }
        }

    }
}
