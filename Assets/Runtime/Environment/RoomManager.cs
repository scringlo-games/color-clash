using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime.Environment
{
    public class RoomManager : MonoBehaviour
    {
        [SerializeField]
        private RoomListScriptableObject roomContainer;
        public static int roomIndex = 0;
        
        public void NextRoom()
        {
            roomIndex++;
            SceneManager.LoadScene(this.roomContainer.roomList[roomIndex]);
        }
    }
}
