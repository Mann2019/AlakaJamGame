using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HighScores
{
    public int HighScore;
}

public class GameController : MonoBehaviour {

    public GameObject[] weaponPrefabs;
    public Transform spawnPoint;
    public Text score;
    public Toggle[] weapons;
    public ToggleGroup weaponGroup;
    public Toggle[] elements;
    public ToggleGroup elementsGroup;

    public static int currentScore = 0;

    private GameObject weaponPrefab;
    private BombLauncher bl;
    private ElementProperties ep;
    private int selWep;

    public void AddProperties()
    {
        /*if(elementsGroup.AnyTogglesOn())
        {
            for(int i=0;i<elements.Length;i++)
            {
                if(elements[i].isOn)
                {
                    ep = elements[i].GetComponent<ElementProperties>();
                    bl.horizontal = bl.horizontal+ep.hort/100;
                    bl.bombMass = bl.bombMass + ep.elemMass/100;
                    bl.explosionRadius = bl.explosionRadius + ep.explodeRad/100;
                }
            }
        }*/
    }

    public void SelectedWeapon()
    {
        if(weaponGroup.AnyTogglesOn())
        {
            for(int i=0;i<weapons.Length;i++)
            {
                if(weapons[i].isOn)
                {
                    selWep = i;
                }
            }
        }
    }

    private void Update()
    {
        score.text = currentScore.ToString();
        SelectedWeapon();
        weaponPrefab = weaponPrefabs[selWep];
        bl = weaponPrefab.GetComponent<BombLauncher>();
    }

    public void GenerateWeapon()
    {
        Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
