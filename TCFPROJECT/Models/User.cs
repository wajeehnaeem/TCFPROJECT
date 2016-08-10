using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCFPROJECT.Models
{
    
    public class UserLogin : IdentityUserLogin
    {
       
    }
    public class UserClaim : IdentityUserClaim { }
    public class Role : IdentityRole {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
    }
    public class User : IdentityUser
    {
        
        public virtual ICollection<Level> Levels { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        
        public DateTime DateOfJoining { get; set; }
       
        public string CNIC { get; set; }
        public string ParentCNIC { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public Session Session { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
    }//done
    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<QuestionClaim> Questions { get; set; }
    }//done
    public class QuestionClaim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public Designation Designation { get; set; }
    }//done
    public class Level
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LevelId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<QuestionClaim> QuestionClaims { get; set; }
        public virtual ICollection<University> Universitys { get; set; }

    }//done
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public QuestionClaim Question { get; set; }
        public User User { get; set; }
        public string AnswerValue { get; set; }
    }//done
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Cluster> Clusters { get; set; }
    }//done
    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Cluster Cluster { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }//done
    public class Cluster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }//done
    public class Session
    {
        public string YearFrom { set; get; }
        public string YearTo { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Class Class { get; set; }
    }//done
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GradeName { get; set; }
        public School School { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }//done
    public class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Level> Levels { get; set; }

    }//done




}