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
                if (!data.state)
                {
                    for (int i = 0; i < data.totalSteps / 20; i++)
                    {
                        DoMoveZ(!data.state);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                    yield return new WaitForSeconds(0.1f);

                    for (int i = 0; i < data.totalSteps; i++)
                    {
                        DoMove(data.state);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                }
                else
                {
                    for (int i = 0; i < data.totalSteps; i++)
                    {
                        DoMove(data.state);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }
                    yield return new WaitForSeconds(0.1f);
                    for (int i = 0; i < data.totalSteps / 20; i++)
                    {
                        DoMoveZ(!data.state);
                        yield return new WaitForSeconds(data.MoveTime / data.totalSteps);
                    }

                }
                data.state = !data.state;
                data.moving = false;
            }
            else yield break;

            yield break;
        }

        void Callmove(Transform t, int dir = 0)
        {
            t.Translate(((Vector2)data.moveDist / data.totalSteps * dir) * Time.deltaTime);
        }

        void CallmoveZ(Transform t, int dir = 0)
        {
            t.Translate((new Vector3(0f, 0f, data.moveDist.z) / (data.totalSteps / 5f) * dir)*Time.deltaTime);
        }

        void DoMove(bool inverted)
        {
            foreach (MoveData.Target t in data.Targets)
                if (inverted)
                    Callmove(t.Trans, 1);
                else
                    Callmove(t.Trans, -1);
        }

        void DoMoveZ(bool inverted)
        {
            foreach (MoveData.Target t in data.Targets)
                if (t.inversed == inverted)
                    CallmoveZ(t.Trans, 1);
                else
                    CallmoveZ(t.Trans, -1);
        }

        [System.Serializable]
        class MoveData
        {
            [System.Serializable]
            public class Target
            {
                public Transform Trans = null;
                public bool inversed = false;
            }
            public Target[] Targets = null;
            public float MoveTime = 0;
            public int totalSteps = 0;
            public bool state = false, moving = false;
            public Vector3 moveDist = Vector3.zero;
        }
    }
}