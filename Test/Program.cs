using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Test
{
    public static class Program
    {
        static void Main()
        {
            // setup
            using (var db = new MyDbContext())
            {
                var assessment = new Assessment
                {
                    Contract = new Contract
                    {
                        Companies = new[]
                        {
                            new Company
                            {
                                Signatories = new[]
                                {
                                    new Signatory
                                    {
                                        Name = "Foo"
                                    }
                                }
                            }
                        }
                    }
                };
                db.Add(assessment);
                db.SaveChanges();
            }

            // tests
            using (var db = new MyDbContext())
            {
                var assessment = db.Assessments.Single();
                if (assessment.Contract != null) throw new Exception("We did not include Contract");
                assessment = db.Assessments
                    .Include(x => x.Contract.Companies)
                        .ThenInclude(x => x.Signatories)
                    .Single();
                if (assessment.Contract == null) throw new Exception("We included Contract");
                if (assessment.Contract.Companies == null) throw new Exception("We included Companies");
                foreach (var company in assessment.Contract.Companies)
                {
                    if (company.Signatories == null) throw new Exception("We included Signatories");
                }
                Console.WriteLine("All good");
            }
        }
    }
}
