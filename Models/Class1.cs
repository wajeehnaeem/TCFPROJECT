using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public partial class User : IdentityUser
    {

        public virtual ICollection<Level> Levels { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [RegularExpression(@"\d{5}-\d{7}-\d")]
        public string CNIC { get; set; }
        public string ParentCNIC { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public Session Session { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
    }//done
    public partial class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<QuestionClaim> Questions { get; set; }
    }//done
    public partial class QuestionClaim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public Designation Designation { get; set; }
    }//done
    public partial class Level
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<QuestionClaim> QuestionClaims { get; set; }
        public virtual ICollection<University> Universitys { get; set; }

    }//done
    public partial class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public QuestionClaim Question { get; set; }
        public User User { get; set; }
        public string AnswerValue { get; set; }
    }//done
    public partial class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Cluster> Clusters { get; set; }
    }//done
    public partial class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Cluster Cluster { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }//done
    public partial class Cluster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }//done
    public partial class Session
    {
        public string YearFrom { set; get; }
        public string YearTo { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Class Class { get; set; }
    }//done
    public partial class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GradeName { get; set; }
        public School School { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }//done
    public partial class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Level> Levels { get; set; }

    }//done




}

