using UnityEngine;
using System.Collections;
namespace Mechanismes
{
    public class Door : BasicUse
    {
        [SerializeField]
        MoveData data = new MoveData();

        protected override void UseObj()
        {
            StartCoroutine(moveDoor());
        }

        IEnumerator moveDoor()
        {
            if (!data.moving)
            {
                data.moving = true;
                int i = 0;
                if (data.state)
                {
                    while (i < data.totalSteps)
                    {
                        i++;
                        Callmove(1);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                }
                else
                {
                    while (i < data.totalSteps)
                    {
                        i++;
                        Callmove(-1);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                }
                data.state = !data.state;
                data.moving = false;
            }
            else yield break;

            yield break;
        }

        void Callmove(int dir = 0){
            data.Target.Translate(data.moveDist / data.totalSteps *dir);
            }

        [System.Serializable]
        class MoveData
        {
            public Transform Target;
            public float MoveTime;
            public int totalSteps;
            public bool state, moving;
            public Vector3 moveDist;
        }
    }
}