using System;
using System.Collections.Generic;
using UnityEngine;
using Utilty;
namespace UIFrame
{
    public class UIConfigurationManager : Singleton<UIConfigurationManager>
    {
        /// <summary>
        /// 所有模块名字和路径
        /// </summary>
        Dictionary<string, string> panelsNamePath;
        Dictionary<string, string> widgetNamePath;
        private UIConfigurationManager()
        {
            panelsNamePath = new Dictionary<string, string>();
            widgetNamePath = new Dictionary<string, string>();
            localiztionTexts = new Dictionary<string, string[]>();
        }

        private void LoadPanelConfig()
        {
            //加载Json
            string configJsonText = AssetsManager.GetInstance().
                GetAssets<TextAsset>(SystemDefine.UIPanelConfigPath).text;
            //Json解析
            var moduleConfig = JsonUtility.FromJson<UIModulePathModel>(configJsonText);
            //先清空字典
            panelsNamePath.Clear();
            AssetsManager.GetInstance().UnloadUselessAssets();
            for (int i = 0; i < moduleConfig.UIPanels.Length; i++)
            {
                panelsNamePath.Add(moduleConfig.UIPanels[i].PanelName,moduleConfig.UIPanels[i].PanelPath);
            }
        }
        private void LoadWidgetConfig()
        {
            //加载Json
            string configJsonText = AssetsManager.GetInstance().
                GetAssets<TextAsset>(SystemDefine.UIWidgetConfigPath).text;
            //Json解析
            var widgetModel = JsonUtility.FromJson<UIWidgetPathModel>(configJsonText);
            //先清空字典
            widgetNamePath.Clear();
            AssetsManager.GetInstance().UnloadUselessAssets();
            for (int i = 0; i < widgetModel.UIWidgetMsgs.Length; i++)
            {
                widgetNamePath.Add(widgetModel.UIWidgetMsgs[i].WidgetName, 
                    widgetModel.UIWidgetMsgs[i].WidgetPath);
            }
        }
        /// <summary>
        /// 通过名称获取路径
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public string GetPanelAssetPathByName(string panelName)
        {
            if (panelsNamePath.Count == 0)
            {
                LoadPanelConfig();
            }
            if (panelsNamePath.ContainsKey(panelName))
            {
                return panelsNamePath[panelName];
            }
            Debug.LogError($"没有找到{panelName}的路径");
            return null;
        }
        public string GetWidgetAssetPathByName(string widgetName)
        {
            if (widgetNamePath.Count == 0)
            {
                LoadWidgetConfig();
            }
            if (!widgetNamePath.ContainsKey(widgetName) || widgetNamePath[widgetName] == null)
            {
                throw new Exception("没有找到对应元件" + widgetName);
            }
            else
            {
                return widgetNamePath[widgetName];
            }
        }

        #region UI Localization Text Config


        /// <summary>
        /// 本地化语言库
        /// </summary>
        private Dictionary<string, string[]> localiztionTexts;

        private void LoadLocaliztionText()
        {

            //加载Json
            string localizationText = AssetsManager.GetInstance().
                GetAssets<TextAsset>(SystemDefine.UITextLocalizationConfigPath).text;
            //Json解析
            var localiztionTextConfig = JsonUtility.FromJson<UILocaliztionTextModel>(localizationText);
            //先清空字典
            localiztionTexts.Clear();
            for (int i = 0; i < localiztionTextConfig.localizationTexts.Length; i++)
            {
                localiztionTexts.Add(
                    localiztionTextConfig.localizationTexts[i].texts[0],
                    localiztionTextConfig.localizationTexts[i].texts);
            }
        }

        /// <summary>
        /// 通过语言ID获取对应的本地化文本
        /// </summary>
        /// <param name="textStr">英文文本的KEY</param>
        /// <param name="languageID">语言id</param>
        /// <returns></returns>
        public string GetTextStringByLanguageID(string textStr,int languageID)
        {
            //懒加载
            if (localiztionTexts.Count == 0)
            {
                LoadLocaliztionText();
            }

            if (!localiztionTexts.ContainsKey(textStr))
            {
                throw new System.Exception($"未找到{textStr}所对应的文本");
            }
            else if(localiztionTexts[textStr] == null)
            {
                throw new System.Exception("配置文件错误请检查");
            }
            else
            {
                return localiztionTexts[textStr][languageID];
            }
        }
        #endregion
    }
}
