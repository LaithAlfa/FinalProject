using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace FinalProject.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
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
                  new Member { FirstName="Laith", LastName="Alfaloujeh", Major="CIS", Email="LAlfaloujeh@buffs.wtamu.edu", Phone="345-484-4685", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Mekkala", LastName="Bourapa", Major="CIS", Email="MBourapa@buffs.wtamu.edu", Phone="456-345-5693", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Charles", LastName="Coufal", Major="CIS", Email="CCoufal@buffs.wtamu.edu", Phone="579-678-4569", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="John", LastName="Cunningham", Major="CIS", Email="JCunningham@buffs.wtamu.edu", Phone="862-234-5762" , MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Michael", LastName="Hayes", Major="CIS", Email="MHayes@buffs.wtamu.edu", Phone="324-234-6852" , MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Aaron", LastName="Hebert", Major="CIS", Email="AHebert@buffs.wtamu.edu", Phone="345-756-7854", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Yi Fu", LastName="Ji", Major="CIS", Email="YJi@buffs.wtamu.edu", Phone="678-547-5694", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Todd", LastName="Kile", Major="CIS", Email="TKile@buffs.wtamu.edu", Phone="324-475-2341", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Mara", LastName="Kinoff", Major="CIS", Email="MKinoff@buffs.wtamu.edu", Phone="243-761-5468", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                    new Member { FirstName="Cesareo", LastName="Lona", Major="CIS", Email="CLona@buffs.wtamu.edu", Phone="546-456-3524", MemberDescription="People who are adventurous seek out the fun in life. They love to try something new--sometimes an act that others would find scary. Adventurous people love to travel and try new foods at a restaurant." },
                   
                  
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
                    new Project { ProjectName="Build a Blog Site", ProjectDescription="Customer wants Blogging site so that they can doucument the Adventures ." },
                    new Project { ProjectName="Software Intergration from Java To C#", ProjectDescription="Laith needs to intergrate a software Text editor from Java to C#." },
                    new Project { ProjectName="Create a DataBase", ProjectDescription="Create a full functional Database." }
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