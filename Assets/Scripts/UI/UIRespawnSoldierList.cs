using AI;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIRespawnSoldierList : MonoBehaviour
    {
        private void Start()
        {
            GameObject template = GameObject.Find("Template");
            GameObject info;
            foreach (GameObject ai in GameObject.FindGameObjectsWithTag("AI"))
            {
                info = Instantiate(template, transform);
                
                Transform parentTransform = info.transform;
                SoldierInfo soldierInfo = ai.GetComponent<AIController>().soldierInfo;

                parentTransform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"{soldierInfo.firstName} {soldierInfo.lastName}";
                parentTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    $"Věk: {soldierInfo.age}";
                parentTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text =
                    $"Původ: {soldierInfo.city}";
                parentTransform.GetChild(3).GetComponent<TextMeshProUGUI>().text =
                    $"Hodnost: {soldierInfo.rank}";
            }
            DestroyImmediate(template);
        }
    }
}