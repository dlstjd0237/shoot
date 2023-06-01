using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManeager : MonoBehaviour
{
    public bool m_isButtonDowning;

    public void PointerDown()
    {
        m_isButtonDowning = true;
    }
    public void PointerUp()
    {
        m_isButtonDowning = false;
    }
}
