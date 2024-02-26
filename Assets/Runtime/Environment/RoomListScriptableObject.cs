using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Environment
{
    [CreateAssetMenu(fileName = "Room List" , menuName = "Scriptables/RoomListScriptableObject")]
    public class RoomListScriptableObject : ScriptableObject
    {
       public List<string> roomList;
    }
}
