﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameFrameX.Asset.Runtime;
using GameFrameX.ObjectPool;

namespace GameFrameX.UI.Runtime
{
    /// <summary>
    /// 界面管理器接口。
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// 获取界面组数量。
        /// </summary>
        int UIGroupCount { get; }

        /// <summary>
        /// 获取或设置界面实例对象池自动释放可释放对象的间隔秒数。
        /// </summary>
        float InstanceAutoReleaseInterval { get; set; }

        /// <summary>
        /// 获取或设置界面实例对象池的容量。
        /// </summary>
        int InstanceCapacity { get; set; }

        /// <summary>
        /// 获取或设置界面实例对象池对象过期秒数。
        /// </summary>
        float InstanceExpireTime { get; set; }

        /*/// <summary>
        /// 获取或设置界面实例对象池的优先级。
        /// </summary>
        int InstancePriority { get; set; }*/

        /// <summary>
        /// 打开界面成功事件。
        /// </summary>
        event EventHandler<OpenUIFormSuccessEventArgs> OpenUIFormSuccess;

        /// <summary>
        /// 打开界面失败事件。
        /// </summary>
        event EventHandler<OpenUIFormFailureEventArgs> OpenUIFormFailure;

        /*
        /// <summary>
        /// 打开界面更新事件。
        /// </summary>
        event EventHandler<OpenUIFormUpdateEventArgs> OpenUIFormUpdate;

        /// <summary>
        /// 打开界面时加载依赖资源事件。
        /// </summary>
        event EventHandler<OpenUIFormDependencyAssetEventArgs> OpenUIFormDependencyAsset;*/

        /// <summary>
        /// 关闭界面完成事件。
        /// </summary>
        event EventHandler<CloseUIFormCompleteEventArgs> CloseUIFormComplete;

        /// <summary>
        /// 设置对象池管理器。
        /// </summary>
        /// <param name="objectPoolManager">对象池管理器。</param>
        void SetObjectPoolManager(IObjectPoolManager objectPoolManager);

        /// <summary>
        /// 设置资源管理器。
        /// </summary>
        /// <param name="assetManager">资源管理器。</param>
        void SetResourceManager(IAssetManager assetManager);

        /// <summary>
        /// 设置界面辅助器。
        /// </summary>
        /// <param name="uiFormHelper">界面辅助器。</param>
        void SetUIFormHelper(IUIFormHelper uiFormHelper);

        /// <summary>
        /// 是否存在界面组。
        /// </summary>
        /// <param name="uiGroupName">界面组名称。</param>
        /// <returns>是否存在界面组。</returns>
        bool HasUIGroup(string uiGroupName);

        /// <summary>
        /// 获取界面组。
        /// </summary>
        /// <param name="uiGroupName">界面组名称。</param>
        /// <returns>要获取的界面组。</returns>
        IUIGroup GetUIGroup(string uiGroupName);

        /// <summary>
        /// 获取所有界面组。
        /// </summary>
        /// <returns>所有界面组。</returns>
        IUIGroup[] GetAllUIGroups();

        /// <summary>
        /// 获取所有界面组。
        /// </summary>
        /// <param name="results">所有界面组。</param>
        void GetAllUIGroups(List<IUIGroup> results);

        /// <summary>
        /// 增加界面组。
        /// </summary>
        /// <param name="uiGroupName">界面组名称。</param>
        /// <param name="uiGroupHelper">界面组辅助器。</param>
        /// <returns>是否增加界面组成功。</returns>
        bool AddUIGroup(string uiGroupName, IUIGroupHelper uiGroupHelper);

        /// <summary>
        /// 增加界面组。
        /// </summary>
        /// <param name="uiGroupName">界面组名称。</param>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="uiGroupHelper">界面组辅助器。</param>
        /// <returns>是否增加界面组成功。</returns>
        bool AddUIGroup(string uiGroupName, int uiGroupDepth, IUIGroupHelper uiGroupHelper);

        /// <summary>
        /// 是否存在界面。
        /// </summary>
        /// <param name="serialId">界面序列编号。</param>
        /// <returns>是否存在界面。</returns>
        bool HasUIForm(int serialId);

        /// <summary>
        /// 是否存在界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <returns>是否存在界面。</returns>
        bool HasUIForm(string uiFormAssetName);

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="serialId">界面序列编号。</param>
        /// <returns>要获取的界面。</returns>
        IUIForm GetUIForm(int serialId);

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <returns>要获取的界面。</returns>
        IUIForm GetUIForm(string uiFormAssetName);

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <returns>要获取的界面。</returns>
        IUIForm[] GetUIForms(string uiFormAssetName);

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <param name="results">要获取的界面。</param>
        void GetUIForms(string uiFormAssetName, List<IUIForm> results);

        /// <summary>
        /// 获取所有已加载的界面。
        /// </summary>
        /// <returns>所有已加载的界面。</returns>
        IUIForm[] GetAllLoadedUIForms();

        /// <summary>
        /// 获取所有已加载的界面。
        /// </summary>
        /// <param name="results">所有已加载的界面。</param>
        void GetAllLoadedUIForms(List<IUIForm> results);

        /// <summary>
        /// 获取所有正在加载界面的序列编号。
        /// </summary>
        /// <returns>所有正在加载界面的序列编号。</returns>
        int[] GetAllLoadingUIFormSerialIds();

        /// <summary>
        /// 获取所有正在加载界面的序列编号。
        /// </summary>
        /// <param name="results">所有正在加载界面的序列编号。</param>
        void GetAllLoadingUIFormSerialIds(List<int> results);

        /// <summary>
        /// 是否正在加载界面。
        /// </summary>
        /// <param name="serialId">界面序列编号。</param>
        /// <returns>是否正在加载界面。</returns>
        bool IsLoadingUIForm(int serialId);

        /// <summary>
        /// 是否正在加载界面。
        /// </summary>
        /// <param name="uiFormAssetName">界面资源名称。</param>
        /// <returns>是否正在加载界面。</returns>
        bool IsLoadingUIForm(string uiFormAssetName);

        /// <summary>
        /// 是否是合法的界面。
        /// </summary>
        /// <param name="uiForm">界面。</param>
        /// <returns>界面是否合法。</returns>
        bool IsValidUIForm(IUIForm uiForm);

        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiFormAssetPath">界面所在路径</param>
        /// <param name="pauseCoveredUIForm">是否暂停被覆盖的界面。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <param name="isFullScreen">是否全屏</param>
        /// <param name="isMultiple">是否创建新界面</param>
        /// <returns>界面的序列编号。</returns>
        Task<IUIForm> OpenUIFormAsync<T>(string uiFormAssetPath, bool pauseCoveredUIForm, object userData, bool isFullScreen = false, bool isMultiple = false) where T : class, IUIForm;

        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiFormAssetPath">界面所在路径</param>
        /// <param name="uiFormType">界面逻辑类型。</param>
        /// <param name="pauseCoveredUIForm">是否暂停被覆盖的界面。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <param name="isFullScreen">是否全屏</param>
        /// <param name="isMultiple">是否创建新界面</param>
        /// <returns>界面的序列编号。</returns>
        Task<IUIForm> OpenUIFormAsync(string uiFormAssetPath, Type uiFormType, bool pauseCoveredUIForm, object userData, bool isFullScreen = false, bool isMultiple = false);

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="serialId">要关闭界面的序列编号。</param>
        void CloseUIForm(int serialId);

        /// <summary>
        /// 立即关闭界面。
        /// </summary>
        /// <param name="serialId">要关闭界面的序列编号。</param>
        void CloseUIFormNow(int serialId);

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="serialId">要关闭界面的序列编号。</param>
        /// <param name="userData">用户自定义数据。</param>
        void CloseUIForm(int serialId, object userData);

        /// <summary>
        /// 立即关闭界面。
        /// </summary>
        /// <param name="serialId">要关闭界面的序列编号。</param>
        /// <param name="userData">用户自定义数据。</param>
        void CloseUIFormNow(int serialId, object userData);

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="uiForm">要关闭的界面。</param>
        void CloseUIForm(IUIForm uiForm);

        /// <summary>
        /// 立即关闭界面。
        /// </summary>
        /// <param name="uiForm">要关闭的界面。</param>
        void CloseUIFormNow(IUIForm uiForm);

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        /// <typeparam name="T"></typeparam>
        void CloseUIForm<T>(object userData) where T : IUIForm;

        /// <summary>
        /// 立即关闭界面。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        /// <typeparam name="T"></typeparam>
        void CloseUIFormNow<T>(object userData) where T : IUIForm;

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="uiForm">要关闭的界面。</param>
        /// <param name="userData">用户自定义数据。</param>
        void CloseUIForm(IUIForm uiForm, object userData);

        /// <summary>
        /// 立即关闭界面。
        /// </summary>
        /// <param name="uiForm">要关闭的界面。</param>
        /// <param name="userData">用户自定义数据。</param>
        void CloseUIFormNow(IUIForm uiForm, object userData);

        /// <summary>
        /// 关闭所有已加载的界面。
        /// </summary>
        void CloseAllLoadedUIForms();

        /// <summary>
        /// 关闭所有已加载的界面。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        void CloseAllLoadedUIForms(object userData);

        /// <summary>
        /// 关闭所有正在加载的界面。
        /// </summary>
        void CloseAllLoadingUIForms();

        /// <summary>
        /// 激活界面。
        /// </summary>
        /// <param name="uiForm">要激活的界面。</param>
        void RefocusUIForm(IUIForm uiForm);

        /// <summary>
        /// 激活界面。
        /// </summary>
        /// <param name="uiForm">要激活的界面。</param>
        /// <param name="userData">用户自定义数据。</param>
        void RefocusUIForm(IUIForm uiForm, object userData);

        /// <summary>
        /// 设置界面实例是否被加锁。
        /// </summary>
        /// <param name="uiFormInstance">要设置是否被加锁的界面实例。</param>
        /// <param name="locked">界面实例是否被加锁。</param>
        void SetUIFormInstanceLocked(object uiFormInstance, bool locked);
    }
}