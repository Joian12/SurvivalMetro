using UnityEngine;

public class PlayerListNetwork : MonoBehaviour
{
    [SerializeField] private GameObject _playerAvatar;
    public Transform _roomListingContainer;
    
    
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void PopulateAvatarListRPC(int clientIndex) {
        ResetAvatarList();
        for (int i = 0; i < clientIndex; i++) {
            var avatar = Instantiate(_playerAvatar, Vector3.zero, Quaternion.identity);
            avatar.transform.SetParent(_roomListingContainer, false);
        }
    }
    
    private void ResetAvatarList() {
        int avatarCount = _roomListingContainer.transform.childCount;

        if (avatarCount <= 0) {
            return;
        }
        
        for (int i = 0; i < avatarCount; i++) {
            Destroy(_roomListingContainer.GetChild(i).gameObject);
        }
    }
}
