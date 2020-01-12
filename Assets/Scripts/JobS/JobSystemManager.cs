using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;
using Unity.Jobs;
using System.Collections.Generic;
using System;
using JobSystemDB;

public class JobSystemManager 
{
    List<Action> actions = new List<Action>();
    int id;

    /// <summary>
    /// Add list Actions for multithreading
    /// </summary>
    public void AddActions(List<Action> actions) {
        this.actions.AddRange(actions);
    }

    /// <summary>
    /// Start multithreading
    /// </summary>
    public void Run() {
        id = DataJobSystem.CreateThreads(actions);
        var job = new ActionsJob()
        {
            id = id
        };
        JobHandle jobHandle = job.Schedule(actions.Count, 64);
        jobHandle.Complete();
        DataJobSystem.DestroyThreads(id);
    }
}

namespace JobSystemDB {
    public static class DataJobSystem {
        private static List<ActionData> actionDatas = new List<ActionData>(); 


        public static void DestroyThreads(int index) {
            if (index < actionDatas.Count)
            {
                actionDatas.Remove(actionDatas[index]);
            }
        }

        /// <summary>
        /// Create list actions for multithreading and return ID (position in the list)
        /// </summary>
        public static int CreateThreads(List<Action> actions)
        {
            ActionData actionData = new ActionData
            {
                ID = actionDatas.Count,
                allActions = actions
            };

            actionDatas.Add(actionData);
            return actionData.ID;
        }

        /// <summary>
        /// Return all actions from ActionData with index
        /// </summary>
        public static List<Action> GetActions(int index) {
            return actionDatas[index].allActions;
        }
    }



    public class ActionData {
        public int ID;
        public List<Action> allActions = new List<Action>();
    }

    public struct ActionsJob : IJobParallelFor
    {
        public int id;
        // The code actually running on the job
        public void Execute(int i)
        {
            // Call Actions
            List<Action> actions = DataJobSystem.GetActions(id);
            actions[i]?.Invoke();
        }
    }
    
}
