using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Friendship
    {
        public int FriendShipId { get; set; }

        //Foreign Key
    [ForeignKey("User1Id")]
        public string User1Id { get; set; }
        public User User1 { get; set; }  // Navigation property for User1
        //Foreign Key
      [ForeignKey("User2Id")]
        public string User2Id { get; set; }
         public User User2 { get; set; }  // Navigation property for User2

        public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
    }

    public enum FriendshipStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}