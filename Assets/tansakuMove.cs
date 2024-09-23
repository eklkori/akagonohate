using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tansakuMove : MonoBehaviour
{
    //‘fŞ‚Ì’è‹`
    [SerializeField] GameObject shitaBtn;
    [SerializeField] GameObject ueBtn;

    /// <summary>
    /// ’Tõ‰æ–Ê‚ğ‰º‚É“®‚©‚·ˆ—
    /// </summary>
    public void moveDown()
    {
        shitaBtn.SetActive(false);
        ueBtn.SetActive(true);
    }

    /// <summary>
    /// ’Tõ‰æ–Ê‚ğã‚É“®‚©‚·ˆ—
    /// </summary>
    public void moveUp()
    {
        ueBtn.SetActive(false);
        shitaBtn.SetActive(true);
    }
}
