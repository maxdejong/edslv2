//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDSL_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        public string matchID { get; set; }
        public string roundPID { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public Nullable<int> homeGoal { get; set; }
        public Nullable<int> awayGoal { get; set; }
    }
}
