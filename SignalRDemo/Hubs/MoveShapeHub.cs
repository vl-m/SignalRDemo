using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Models;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    public class MoveShapeHub : Hub
    {
        // Is set via the constructor on each creation
        private MoveShape _broadcaster;
        public MoveShapeHub()
            : this(MoveShape.Instance)
        {
        }
        public MoveShapeHub(MoveShape broadcaster)
        {
            _broadcaster = broadcaster;
        }
        public void UpdateModel(ShapeModel clientModel)
        {
            clientModel.LastUpdatedBy = Context.ConnectionId;
            // Update the shape model within our broadcaster
            _broadcaster.UpdateShape(clientModel);
        }
    }
}