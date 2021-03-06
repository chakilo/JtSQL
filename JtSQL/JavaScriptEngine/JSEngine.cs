﻿// ====================================================================== //
//
//  JSEngine
//  Chakilo.JavaScriptEngine
// 
//  Created by konar on 12/28/2017 4:07:58 PM.
//  Copyright © 2017 konar. All rights reserved.
//  
// 
// ====================================================================== //

using Jint;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Chakilo.JavaScriptEngine {
    internal class JSEngine {

        #region 成员

        /// <summary>
        /// JS引擎
        /// </summary>
        private Engine _engine;

        #endregion

        #region 构造器

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="assembly">传入引擎的组件</param>
        internal JSEngine(Assembly assembly) {
            // JS引擎
            _engine = new Engine(cfg => cfg.AllowClr(assembly));
        }

        #endregion

        #region 方法

        #region 私有方法

        #endregion

        #region 公开方法

        /// <summary>
        /// 注入代码
        /// </summary>
        /// <param name="source"></param>
        internal void Execute(String source) {
            _engine.Execute(source);
        }

        #endregion

        #endregion

    }
}
