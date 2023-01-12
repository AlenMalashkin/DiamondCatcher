using Location;
using UnityEngine;
using UnityEngine.UI;


namespace PlayerProfile
{
    public class RecordCard : MonoBehaviour
    {
        [SerializeField] private Image _locationImage;
        [SerializeField] private Text _locationName;
        [SerializeField] private Text _recordText;

        public void Init(LocationParams locationParams)
        {
            _locationImage.sprite = locationParams.background;
            _locationName.text = locationParams.locationName;
            _recordText.text = PlayerPrefs.GetInt(locationParams.recordSavePath, 0).ToString();
        }
    }
}