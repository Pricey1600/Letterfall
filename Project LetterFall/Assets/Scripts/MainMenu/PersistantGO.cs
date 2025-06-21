using UnityEngine;

public class PersistantGO : MonoBehaviour
{
    private void Awake() {
        string thisTag = this.gameObject.tag.ToString();
        GameObject[] objs = GameObject.FindGameObjectsWithTag(thisTag);
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
