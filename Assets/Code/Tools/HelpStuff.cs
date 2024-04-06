using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Class with public static funcs
public static class GlobalHelpers
{
    // Use: transform.ShowMyName();
    public static void ShowMyName(this Transform t) => Debug.Log(t.name);
    // Use: transform.ShowMyPosition();
    public static void ShowMyPosition(this Transform t) => Debug.Log(t.position);

    // Use: transform.ActiveChildren();
    public static void ActiveChildren(this Transform t) => ChangeActiveChildren(t, true);

    // Use: transform.DeactiveChildren();
    public static void DeactiveChildren(this Transform t) => ChangeActiveChildren(t, false);

    // Use: transform.DeactiveChildren();
    public static void ChangeActiveChildren(this Transform t, bool active)
    {
        foreach (Transform child in t) child.gameObject.SetActive(active);
    }

    // Use: transform.DestroyChildren();
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }
}

//Class for counting time
public static class Timer
{
    public async static Task Wait(float waitTime)
    {
        float endTime = Time.time + waitTime;
        while (Time.time < endTime)
        {
            await Task.Yield();
        }
    }
}

//Class for mouse pointer operations
public class Pointer
    {

        public static Vector3 GetPointerWorldPosition2D()
        {
            return GetPointerWorldPosition2D(Camera.main);
        }

        public static Vector3 GetPointerWorldPosition2D(Camera camera)
        {
            Vector3 v3 = GetPointerWorldPosition3D(Input.mousePosition, camera);
            v3.z = 0f;
            return v3;
        }

        public static Vector3 GetPointerWorldPosition3D()
        {
            return GetPointerWorldPosition3D(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetPointerWorldPosition3D(Camera camera)
        {
            return GetPointerWorldPosition3D(Input.mousePosition, camera);
        }

        public static Vector3 GetPointerWorldPosition3D(Vector3 screenPos, Camera camera)
        {
            Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
            return worldPos;
        }
    }

    public class Utils
    {
        public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
        {
            position.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(position);
        }

        public static Vector3 ScreenToWorld3D(Camera camera, Vector3 position)
        {
            return camera.ScreenToWorldPoint(position);
        }
    }

    //Class for work with Lists
    [System.Serializable]
    class XList<T> : List<T>
    {
        public void Shuffle()
        {
            System.Random rand = new System.Random();

            for (int i = this.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = this[j];
                this[j] = this[i];
                this[i] = tmp;
            }
        }

        public T Random()
        {
            System.Random rand = new System.Random();
            int index = rand.Next(this.Count);
            return this[index];
        }

        public List<T> Random(int count)
        {
            List<T> temp = new List<T>();
            System.Random rand = new System.Random();
            
            while(temp.Count < count)
            {
                int index = rand.Next(this.Count);
                if (!temp.Contains(this[index]))
                    temp.Add(this[index]);
            }
            return temp;
        }
    }

    // Class for easy scene managment
    public class Loader
    {
        public static void Load(int scene) => SceneManager.LoadScene(scene);

        public static void Load(string scene) => SceneManager.LoadScene(scene);

        public static void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static int GetScene() => SceneManager.GetActiveScene().buildIndex;

        public static void NextScene() => SceneManager.LoadScene(GetScene() + 1);
    }

    // Class for get an angle from something
    public class Angle
    {
        public static float GetFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }

    }

    public class Slope
    {
        public static Vector3 GetSlopeDirection(Vector3 oldDirection, RaycastHit slopeHit)
        {
            return Vector3.ProjectOnPlane(oldDirection, slopeHit.normal).normalized;
        }

        public static Vector3 GetSlopeVector(Vector3 oldVector, RaycastHit slopeHit)
        {
            return Vector3.ProjectOnPlane(oldVector, slopeHit.normal);
        }
    }

    // Class for wrapping array objects for Json
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }