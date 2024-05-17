using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.FriendShip;
using backend.Models;

namespace backend.Mappers
{
    public class FriendshipMapper
    {
        //map from friendship to dto
        public GetFriendShipDto MapToDto(Friendship friendship)
        {
            return new GetFriendShipDto
            {
                FriendShipId = friendship.FriendShipId,
                User1Id = friendship.User1Id,
                User2Id = friendship.User2Id,
                Status = (Dtos.FriendShip.FriendshipStatus)friendship.Status
            };
        }
    }
}
