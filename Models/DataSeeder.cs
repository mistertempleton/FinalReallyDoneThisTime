using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuffteksWebsite.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BuffteksWebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {
                 try
                {

                    //no matter what, delete and then create
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();


                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                   new Client { FirstName="Tanja  ", LastName="Sandi", CompanyName="ZWT Enterprises", Email="TSandi@ZWT.com", Phone="684-891-3451" },
                   new Client { FirstName="Eren", LastName="Ilithyia", CompanyName="Wizards of the Coast Inc.", Email="eren.Ilithyia@wotc.com", Phone="143-456-7865" },
                   new Client { FirstName="Martin", LastName="Biagino", CompanyName="Biagino Home Repair", Email="ceo@Biaginorepair.com", Phone="714-739-5237" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                  new Member { FirstName="Laith", LastName="Alfaloujeh", Major="CIS", Email="LAlfaloujeh@buffs.wtamu.edu", Phone="345-484-4685" },
                    new Member { FirstName="Mekkala", LastName="Bourapa", Major="CIS", Email="MBourapa@buffs.wtamu.edu", Phone="456-345-5693" },
                    new Member { FirstName="Charles", LastName="Coufal", Major="CIS", Email="CCoufal@buffs.wtamu.edu", Phone="579-678-4569" },
                    new Member { FirstName="John", LastName="Cunningham", Major="CIS", Email="JCunningham@buffs.wtamu.edu", Phone="862-234-5762" },
                    new Member { FirstName="Michael", LastName="Hayes", Major="CIS", Email="MHayes@buffs.wtamu.edu", Phone="324-234-6852" },
                    new Member { FirstName="Aaron", LastName="Hebert", Major="CIS", Email="AHebert@buffs.wtamu.edu", Phone="345-756-7854" },
                    new Member { FirstName="Yi Fu", LastName="Ji", Major="CIS", Email="YJi@buffs.wtamu.edu", Phone="678-547-5694" },
                    new Member { FirstName="Todd", LastName="Kile", Major="CIS", Email="TKile@buffs.wtamu.edu", Phone="324-475-2341"},
                    new Member { FirstName="Mara", LastName="Kinoff", Major="CIS", Email="MKinoff@buffs.wtamu.edu", Phone="243-761-5468"},
                    new Member { FirstName="Cesareo", LastName="Lona", Major="CIS", Email="CLona@buffs.wtamu.edu", Phone="546-456-3524"},
                    new Member { FirstName="Michaael", LastName="Matthews", Major="CIS", Email="MMatthews@buffs.wtamu.edu", Phone="243-557-7861"},
                    new Member { FirstName="Mason", LastName="McCollum", Major="CIS", Email="MMcCollum@buffs.wtamu.edu", Phone="851-456-4756"},
                    new Member { FirstName="Alexander", LastName="McDonald", Major="CIS", Email="AMcDonald@buffs.wtamu.edu", Phone="345-573-5675"},
                    new Member { FirstName="Catherine", LastName="McGovern", Major="CIS", Email="CMcGovern@buffs.wtamu.edu", Phone="756-786-4765"},
                    new Member { FirstName="Phelps", LastName="Merrell", Major="CIS", Email="PMerrell@buffs.wtamu.edu", Phone="867-125-0512"},
                    new Member { FirstName="Quan", LastName="Nguyen", Major="CIS", Email="QNguyen@buffs.wtamu.edu", Phone="551-435-5841"},
                    new Member { FirstName="Alex", LastName="Roder", Major="CIS", Email="ajroder2@buffs.wtamu.edu", Phone="865-456-7653"},
                    new Member { FirstName="Amy", LastName="Saysouriyosack", Major="CIS", Email="ASaysouriyosack@buffs.wtamu.edu", Phone="234-712-6523"},
                    new Member { FirstName="Claudia", LastName="Silva", Major="CIS", Email="CSilva@buffs.wtamu.edu", Phone="756-752-6735"},
                    new Member { FirstName="Gabriela", LastName="Valenzuela", Major="CIS", Email="GValenzuela@buffs.wtamu.edu", Phone="325-562-5668"},
                    new Member { FirstName="Kayla", LastName="Washington", Major="CIS", Email="KWashington@buffs.wtamu.edu", Phone="876-751-1237"},
                    new Member { FirstName="Matthew", LastName="Webb", Major="CIS", Email="MWebb@buffs.wtamu.edu", Phone="906-856-4355"},
                    new Member { FirstName="Cory", LastName="Williams", Major="CIS", Email="CWilliams@buffs.wtamu.edu", Phone="173-455-7413"}
                  
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="Build a Website", ProjectDescription="Customer wants site to rival Amazon on a budget of -$0." },
                    new Project { ProjectName="Build a game", ProjectDescription="Bethesda needs help fixing Fallout 76." },
                    new Project { ProjectName="Build a new internet", ProjectDescription="The one we have now is lame, so we should start over." }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();  
                }  

                 catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }                          

            }
        }
    }
}