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
                    yield return new WaitForSeconds(0.1f);

                    i = 0;
                    while (i < data.totalSteps / 20)
                    {
                        i++;
                        CallmoveZ(1);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                }
                else
                {
                    while (i < data.totalSteps / 20)
                    {
                        i++;
                        CallmoveZ(-1);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                    yield return new WaitForSeconds(0.1f);
                    i = 0;
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
            data.Target.Translate((Vector2)data.moveDist / data.totalSteps *dir);
            }

        void CallmoveZ(int dir = 0)
        {
            data.Target.Translate(new Vector3(0f, 0f, data.moveDist.z) / (data.totalSteps / 5f) * dir);
        }
        [System.Serializable]
        class MoveData
        {
            public Transform Target = null;
            public float MoveTime = 0;
            public int totalSteps = 0;
            public bool state = false, moving = false;
            public Vector3 moveDist = Vector3.zero;
        }
    }
}