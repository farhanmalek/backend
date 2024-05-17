using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.FriendShip
{
    //The friendship dto we send back to the client
    public class GetFriendShipDto
    {
        public int FriendShipId { get; set; }
        public string User1Id { get; set; }
         public string User2Id { get; set; }
         public FriendshipStatus Status { get; set; }
    }

    
    public enum FriendshipStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}