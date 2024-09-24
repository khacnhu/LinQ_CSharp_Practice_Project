using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6 };

            int[] listInt = new int[] { 1, 2, 3, 4 };

            var checkmq = listInt.Any(e => e > 5);

            var q = (from obj in listInt select obj).All(x => x > 5);



            var mq = listInt.Reverse();

            var msListInt = (from obj in listInt select obj).Reverse().ToList();




            var que = (from num in lst where num > 4 orderby num descending select num).ToList();
            var methodSyn = lst.Where(num => num > 4).OrderBy(num => num).ToList();

            List<string> lstString = new List<string>() { "nhu", "tran", "khac", "bao", "bach" };

            var isExist = lstString.AsEnumerable().Contains("t");



            var newListStr = lstString.AsEnumerable().Reverse();



            var questr = (from letter in lstString where letter.Length > 3 orderby letter select letter).ToList();
            var methodSynstr = lstString.Where(letter => letter.Length > 4).OrderBy(letter => letter).ToList();



            List<Employee> employees = new List<Employee>() {
                new Employee() {Id = 1, Name = "tran khac nhu"},
                new Employee() {Id = 2, Name = "le thi thanh trang"},
                new Employee() {Id = 3, Name = "vo thi hong nhu"},
                new Employee() {Id = 4, Name = "kim anh nha"},
                new Employee() {Id = 5, Name = "tran hau thien" }
            };

            IEnumerable<Employee> query = from e in employees where e.Id == 1 select e;

            IQueryable<Employee> queryone = employees.AsQueryable().Where(e => e.Id == 3);

            var basicQuery = (from e in employees select e).ToList();

            var basicMethod = employees.ToList();

            var basicPropMethod = employees.Select(e => e.Id + 5).ToList();

            var selectQuery = from e in employees
                              select new Student()
                              {
                                  StudentId = e.Id + 2,
                                  FullName = e.Name + " anaconda " + " fake real",
                                  StdEmail = "DEFAULT@yopmail.com"
                              };

            var selectMethod = employees.Select(e => new Student()
            {
                StudentId = e.Id + 2,
                FullName = e.Name + " anaconda " + " fake real",
                StdEmail = "DEFAULT@yopmail.com"
            }).ToList();

            var selectQue = (from e in employees
                             select new
                             {
                                 SuperId = e.Id + 2,
                                 SuperName = e.Name + " anaconda " + " fake real",
                                 SuperDefault = "DEFAULT@yopmail.com"
                             }).ToList();

            List<string> strLst = new List<string>() { "BA", "cd", "Su", "NH", "Ab" };

            var method = strLst.SelectMany(x => x).ToList();

            var queryRes = (from rec in strLst from ch in rec select ch).ToList();

            List<Employee> datasource = new List<Employee>() {
                new Employee() {Id = 1, Name = "tran khac nhu", Programming = new List<Techs> {
                    new Techs() {Technology = "csharp"},
                    new Techs() {Technology = "python"},
                } },
                new Employee() {Id = 2, Name = "le thi thanh trang", Programming = new List<Techs> {
                    new Techs() {Technology = "ruby"},
                    new Techs() {Technology = "pearl"},
                    new Techs() {Technology = "kotlin"}
                } },
                new Employee() {Id = 3, Name = "vo thi hong nhu", Programming = new List<Techs> {
                    new Techs() {Technology = "golang"},
                    new Techs() {Technology = "python"},
                    new Techs() {Technology = "ruby"}
                } },
            };




            var methodSyntax = datasource.SelectMany(emp => emp.Programming).ToList();

            var methodNew = datasource.Where(emp => emp.Programming.Count >= 3).ToList();

            var querySyntax = (from obj in datasource
                               from skill in obj.Programming
                               where skill.Technology.Length > 8
                               select skill).ToList();


            List<int> lstNum = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            IEnumerable<int> queryNumList = (from num in lstNum
                                             where num > 3 && num % 2 == 0
                                             select num).ToList();



            var methodNums = lstNum.Where(num => num > 3 & num % 2 == 0).ToList();

            List<string> lstStr = new List<string>() { "bao bach", "khac nhu", "con chim", "anh hung", "alo conda" };
            var filterStr = (from i in lstStr
                             where i.Contains("bach")
                             select i).ToList();


            var datanewww = new List<object> { "Adam", "Harry", "Kim", "John", 1, 4, 2, 6 };


            var methd = datanewww.OfType<string>().Where(e => e.Length > 3).ToList();


            var dataHero = new List<Hero>()
            {
                new Hero() {Id = 1, FirstName = "NHU", LastName="TRAN", age =23},
                new Hero() {Id = 2, FirstName = "HOA", LastName="HAN", age = 92},
                new Hero() {Id = 3, FirstName = "COM", LastName="CANH", age = 26},
                new Hero() {Id = 4, FirstName = "KING", LastName="KONG", age = 73}
            };

            var ms = dataHero.OrderBy(hr => hr.FirstName).ThenBy(e => e.age).ToList();


            List<int> newNum = new List<int>() { 2, 5, 6, 2, 6, 8, 9, 4 };

            var msNewNum = newNum.Distinct().Order();

            var mqNewNum = (from obj in newNum select obj).Distinct().Order().ToList();

            var mixQu = newNum.Select(x => x).Distinct().Order().ToList();


            List<Baby> lstBaby = new List<Baby>()
            {
                new Baby() {Id = 1, Name = "baby one"},
                new Baby() {Id = 2, Name = "two baby"},
                new Baby() {Id = 3, Name = "baby three nha"},
                new Baby() {Id = 4, Name = "FOUR baby"},
                new Baby() {Id = 1, Name = "baby one"},
                new Baby() {Id = 2, Name = "baby so hai nha"},
                new Baby() {Id = 5, Name = "FOUR baby"}
            };

            var babyMQ = lstBaby.Distinct(new BabyComparer()).ToList();


            List<string> dtone = new List<string>() { "A", "B", "C", "D" };
            List<string> dttwo = new List<string>() { "C", "D", "E", "F" };



            var msnew = dttwo.Intersect(dtone).ToList();

            var mqnewnana = (from obj in dtone select obj).Intersect(dttwo).ToList();




            List<Boy> boyOne = new List<Boy>()
            {
                new Boy() {Id = 1, Name ="John"},
                new Boy() {Id = 2, Name = "Kim"},
                new Boy() {Id = 3, Name = "John"},
                new Boy() {Id = 4, Name = "Cam"}
            };

            List<Boy> boyTwo = new List<Boy>()
            {
                new Boy() {Id = 1, Name ="King"},
                new Boy() {Id = 2, Name = "Cam"},
                new Boy() {Id = 3, Name = "John"},
                new Boy() {Id = 4, Name = "Kong"}
            };

            var msBoy = boyTwo.Select(x => x.Name).Except(boyOne.Select(e => e.Name)).ToList();

            var msBoyInter = boyOne.Select(x => new { x.Id, x.Name }).Union(boyTwo.Select(e => new { e.Id, e.Name }));

            List<int> arrNum1 = new List<int>() { 2, 5, 1, 2 };
            List<int> arrNum2 = new List<int>() { 4, 6, 1, 3 };

            var arrMq = arrNum1.Union(arrNum2).ToList();
            var arrQue = (from obj in arrNum1 select obj).Union(arrNum2).ToList();


            List<int> oper = new List<int>() { 2, 5, 4, 2, 4, 5 };

            var takeLst = oper.Take(5).ToList();

            var mixq = (from obj in oper select obj).Take(5).ToList();

            var takN = oper.Where(e => e > 3).Take(2).ToList();

            int[] numbers = new int[] { 1, 2, 4, 5, 6, 8, 23, 3, 5, 7, 2, 4 };

            var skiwmt = numbers.SkipWhile(e => e < 23).ToList();



            var skipmt = numbers.Skip(3).ToList();

            var skpr = (from obj in numbers select obj).Skip(3).ToList();


            var msTada = numbers.TakeWhile(e => e < 22).ToList();

            var msTd = (from obj in numbers select obj).TakeWhile(ob => ob < 22).ToList();

            List<string> names = new List<string>() { "Kin", "John", "Mark", "Adam", "Ni" };


            var skmtstr = names.Skip(3).ToList();
            var skqrstr = (from obj in names select obj).Skip(3).ToList();



            var msTdStr = names.TakeWhile((name, index) => name.Length > index).ToList();

            var nstudents = new List<NStuden>()
            {
                new NStuden() {Id = 1, Name = "A", AddressId = 1},
                new NStuden() {Id = 2, Name = "B", AddressId = 3},
                new NStuden() {Id = 3, Name = "C", AddressId = 2},
                new NStuden() {Id = 4, Name = "D", AddressId = 1},
                new NStuden() { Id = 5, Name = "E", AddressId = 4}
            };

            var addresses = new List<Address>()
            {
                new Address() {Id = 1, AddressLine = "Line One"},
                new Address() {Id = 2, AddressLine = "Line Two"},
                new Address() {Id = 3, AddressLine = "Line three"}
            };

            var leftqr = (from std in nstudents
                         join addr in addresses on std.AddressId equals addr.Id into stdAddress
                         from stdAddr in stdAddress.DefaultIfEmpty()
                         select new {stdName = std.Name , Diachi = stdAddr != null ? stdAddr.AddressLine : "no dia chi" }).ToList();

            var leftmethod = nstudents.GroupJoin(addresses, std => std.AddressId, addr => addr.Id, (std, addr) => new
            {
                std,
                addr
            }).SelectMany(x => x.addr.DefaultIfEmpty(), (stdData, addrData) => new
            {
                stdData.std,
                addrData
            }).ToList();


            
            foreach (var e in leftmethod)
            {

            }


            var marks = new List<Marks>()
            {
                new Marks() {Id = 1, StudentId = 1, TMarks = 98},
                new Marks() {Id = 2, StudentId = 5, TMarks = 52},
                new Marks() {Id = 3, StudentId = 3, TMarks = 74},
                new Marks() {Id = 4, StudentId = 2, TMarks = 23},
                new Marks() {Id = 5, StudentId = 4, TMarks = 46}
            };



            var qsjoin = (from std in nstudents
                          join addr in addresses
                          on std.AddressId equals addr.Id
                          join mark in marks
                          on std.Id equals mark.StudentId
                          select new
                          {
                              StudentName = std.Name,
                              Address = addr.AddressLine,
                              Score = mark.TMarks
                          }).ToList();

            var msjoin = nstudents.Join(addresses, std => std.AddressId, address => address.Id, (std, address) => new
            {
                StudentName = std.Name,
                Address = address.AddressLine
            }).ToList();

            var msjointhree = nstudents.Join(addresses,
                    std => std.AddressId,
                    address => address.Id,
                    (std, address) => new { std, address }
                ).
                Join(marks,
                    student => student.std.Id,
                    mark => mark.StudentId,
                    (student, m) => new { student, m }).
                Select(x => new
                {

                    StudentName = x.student.std.Name,
                    Address = x.student.address.AddressLine,
                    Score = x.m.TMarks
                }).ToList();

            

            var lstStd = new List<Std>()
            {
                new Std() {Id = 1, Name = "nhu tran", CategoryId = 2},
                new Std() {Id = 2, Name = "bao bach", CategoryId = 1},
                new Std() {Id = 3, Name = "king kong", CategoryId = 2},
                new Std() {Id = 4, Name = "con cann", CategoryId = 3},
                new Std() {Id = 5, Name = "super hero", CategoryId = 3}
            };

            var lstCate = new List<Category>()
            {
                new Category() {Id = 1, Name = "TOAN"},
                new Category() {Id = 2, Name = "Anh"},
                new Category() {Id = 3, Name = "Van"}   
            };

            var catestd = lstCate.GroupJoin(lstStd, cat => cat.Id, std => std.CategoryId, (cat, stud) => new
            {
                cat,
                stud
            }) ;




            //foreach (var item in catestd)
            //{

            //    Console.WriteLine(item.cat.Name + " =>>>>>>>>>> ");
            //    foreach (var e in item.stud)
            //    {
            //        Console.WriteLine(e.Id + "  :  " + e.Name);

            //    }
            //}


        }

        class Std()
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
        }

        class Category {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Marks
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int TMarks { get; set; }
        }

        class NStuden ()
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int AddressId { get; set; }
        }

        class Address
        {
            public int Id { get; set; }
            public string AddressLine { get; set; }
        }

        class Boy
        {
            public int Id { get; set; } 
            public string Name { get; set; }
        }

        class Baby
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public bool Equals(Baby? other)
            {
                if (object.ReferenceEquals(other, null))
                {
                    return false;
                }

                if (object.ReferenceEquals(this, other))
                {
                    return true;
                }
                return Id.Equals(other.Id) && Name.Equals(other.Name);  
            }

            public override int GetHashCode()
            {
                int idHashCode = Id.GetHashCode();
                int nameHashCode = Name.GetHashCode();
                return idHashCode ^ nameHashCode;
            }
        }

        class BabyComparer : IEqualityComparer<Baby>
        {
            public bool Equals(Baby? x, Baby? y)
            {
                return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
            }

            public int GetHashCode([DisallowNull] Baby obj)
            {
                int idHashCode = obj.Id.GetHashCode();
                int nameHashCode = obj.Name.GetHashCode();
                return idHashCode ^ nameHashCode;
            }
        }


        class Hero
        {
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public int age { get; set; }    
        }

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public List<Techs> Programming { get; set; }
        }

        class Student
        {
            public int StudentId { get; set; }
            public string StdEmail { get; set; }
            public string FullName { get; set; }
        }

        public class Techs
        {
            public string Technology { get; set; }

        }


    }
}
