using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Common
{
    /// <summary>
    /// 游戏对象池:unity平台中使用的单例模式 游戏对象池
    /// </summary>
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {


        private GameObjectPool()
        { }
        //1 创建池：
        private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();

        /// <summary>        ///  获取对象池内的模型列表        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<GameObject>> GetCacheList()
        {
            return cache;
        }


        /// <summary>    /// 返回已经生成的游戏物体    /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public GameObject GetGameObjectByKey(string key)
        {
            if (cache.ContainsKey(key) && cache[key] != null)
            {
                if (cache[key].Count > 0)
                {
                    return cache[key][0];
                }
            }
            return null;
        }


        //2 使用游戏对象：    
        public GameObject CreateObject(string key, GameObject go, Vector3 pos, Quaternion rotation)
        {
            //1>从池中查找key的对象
            GameObject tempGo = FindUsable(key);
            if (tempGo != null)
            {
                //2>池中有从池中返回[出现在画面】
                tempGo.transform.position = pos;
                tempGo.transform.rotation = rotation;
                tempGo.SetActive(true);
            }
            else
            {
                //3>池中没有,【加载】，创建游戏对象, 添加Add到池中,再返回:
                //----1）动态创建预制件对象
                tempGo = Instantiate(go, pos, rotation) as GameObject;
                //----2）添加Add到池中
                Add(key, tempGo);
            }
            //返回 
            //把新建游戏对象 作为子物体 统一管理【父】
            tempGo.transform.parent = this.transform;
            return tempGo;
        }

        public GameObject CreateObject(string key, GameObject go, Transform parent)
        {
            //1>从池中查找key的对象
            GameObject tempGo = FindUsable(key);
            if (tempGo != null)
            {
                //2>池中有从池中返回[出现在画面】

                //   tempGo.transform.position = parent.position;  // 不需要变成父物体的坐标轴
                //  tempGo.transform.rotation = parent.rotation;

                tempGo.SetActive(true);
            }
            else
            {
                //3>池中没有,【加载】，创建游戏对象, 添加Add到池中,再返回:
                //----1）动态创建预制件对象
                tempGo = Instantiate(go, parent) as GameObject;
                //----2）添加Add到池中
                Add(key, tempGo);
            }
            //返回 
            //把新建游戏对象 作为子物体 统一管理【父】
            tempGo.transform.parent = parent;
            return tempGo;
        }

        private void Add(string key, GameObject go)
        {
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new List<GameObject>());
            }
            cache[key].Add(go);
        }
        /// <summary>
        /// 从池中查找key对象
        /// </summary>
        /// <param name="key"></param>
        private GameObject FindUsable(string key)
        {
            //有没有子弹
            //有+是不是可用！【闲置状态】  1》没有闲置null 
            //                                          2》有闲置的返回 ok
            //没有                                   null
            if (cache.ContainsKey(key))
            {
                return cache[key].Find(go => !go.activeSelf);
                //var list = cache[key];
                //foreach(var go in list)
                //{
                //    if (!go.activeSelf)
                //    {
                //        return go;
                //    }
                //} 
            }
            return null;
        }

        //3 释放游戏对象：从池中删除！
        //3.1释放部分：按Key释放 
        public void Clear(string key)
        {
            if (!cache.ContainsKey(key)) return;
            //把引用 对应的 游戏物体 删除-销毁
            List<GameObject> list = cache[key];
            foreach (var go in list)
            {
                DestroyImmediate(go);
            }
            //把池中记录的 游戏物体的 引用 删除
            cache.Remove(key);
        }



        /// <summary>        /// 3.2释放全部         /// </summary>
        public void ClearAll()
        {
            List<string> list = new List<string>(cache.Keys);
            for (int i = 0; i < list.Count; i++)
            {
                Clear(list[i]);
            }
        }

        //4 回收游戏对象：使用完游戏对象返回池中【从画面中消失】
        //4.1即时回收
        /// <summary>        ///  即时回收游戏对象：使用完游戏对象返回池中【从画面中消失】        /// </summary>
        /// <param name="go"></param>
        public void CollectObject(GameObject go)
        {
            go.SetActive(false);
        }
        //4.2延时回收
        public void CollectObject(GameObject go, float delay)
        {
            //协程
            StartCoroutine(DelayCollect(go, delay));
        }
        private IEnumerator DelayCollect(GameObject go, float delay)
        {
            yield return new WaitForSeconds(delay);
            CollectObject(go);
        }

        /// <summary>        ///  回收所有对象        /// </summary>
        public void CollectAllObject()
        {
            foreach (var key in cache.Keys)
            {
                for (int i = 0; i < cache[key].Count; i++)
                {
                    cache[key][i].SetActive(false);
                }
            }
        }


    }
}