/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorInterage : MonoBehaviour
{
    public bool EstaInteragindo { get; private set; }

    void Update()
    {
        if (Input.GetButtonDown("Interage"))
        {
            EstaInteragindo = true;
        }
        else if (Input.GetButtonUp("Interage"))
        {
            EstaInteragindo = false;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JogadorInterage : MonoBehaviour
{
    public bool EstaInteragindo { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interage"))
        {
            EstaInteragindo = true;
        }
        else
        {
            EstaInteragindo = false;
        }
    }
}