using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HighScores
{
    public int HighScore;
}

public class GameController : MonoBehaviour {

    public GameObject[] weaponPrefabs;
    public GameObject[] elementPrefabs;
    public Transform spawnPoint;
    public Text score;
    public Text elemMassValue;
    public Text elemPropValue;
    public Text elemRadValue;
    public Text bombMassValue;
    public Text bombPropValue;
    public Text bombRadValue;
    public Toggle[] weapons;
    public ToggleGroup weaponGroup;
    public Toggle[] elements;
    public ToggleGroup elementsGroup;
    public Camera mainCam;

    public static int currentScore = 0;

    private GameObject weaponPrefab;
    private GameObject elementPrefab;
    private GameObject weapon;
    private CameraController camCon;
    private BombLauncher bl;
    private ElementProperties ep;
    private int selWep;
    private int selEl;
    private float totalBm = 0f;
    private float totalHor = 0f;
    private float totalRad = 0f;

    private void Start()
    {
        camCon = mainCam.GetComponent<CameraController>();
    }

    public void AddProperties()
    {
        ep = elementPrefab.GetComponent<ElementProperties>();
        totalBm = totalBm + ep.elemMass/100;
        float tbm = totalBm * 100;
        totalHor = totalHor + ep.hort/100;
        float thr = totalHor * 100;
        totalRad = totalRad + ep.explodeRad/100;
        float trd = totalRad * 100;
        bombMassValue.text = tbm.ToString();
        bombPropValue.text = thr.ToString();
        bombRadValue.text = trd.ToString();
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

    public void SelectedElement()
    {
        if (elementsGroup.AnyTogglesOn())
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].isOn)
                {
                    selEl = i;
                }
            }
        }
    }

    private void Update()
    {
        score.text = currentScore.ToString();
        SelectedWeapon();
        SelectedElement();
        weaponPrefab = weaponPrefabs[selWep];
        elementPrefab = elementPrefabs[selEl];
        ep = elementPrefab.GetComponent<ElementProperties>();
        elemMassValue.text = ep.elemMass.ToString();
        elemPropValue.text = ep.hort.ToString();
        elemRadValue.text = ep.explodeRad.ToString();
    }

    public void GenerateWeapon()
    {
        weapon = Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation);
        bl = weapon.GetComponent<BombLauncher>();
        camCon.target = weapon.transform;
        bl.horizontal = bl.horizontal + totalHor;
        bl.bombMass = bl.bombMass + totalBm;
        bl.explosionRadius = bl.explosionRadius + totalRad;
    }
}
