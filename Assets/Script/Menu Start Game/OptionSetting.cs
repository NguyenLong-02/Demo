using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

namespace Assets.Script.Menu_Start_Game
{
    public class OptionSetting : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] Dropdown dropdown;
        [SerializeField] List<string> options = new List<string>() { "Low", "Medium", "High", "Very High", "Ultra" };
        // Start is called before the first frame update
        void Start()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }

        public void GraphisSetting(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }

        public void VolumeSetting(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }
}
