﻿// ====================================================================== //
//
//  Work
//  JtSQL.Linq
// 
//  Created by Chakilo on 12/25/2017 10:33:19 AM.
//  Copyright © 2017 Chakilo. All rights reserved.
//  https://github.com/chakilo/JtSQL
// 
// ====================================================================== //

using System;
using System.Collections.Generic;
using System.Text;
using JtSQL.Delegate;
using JtSQL.Exception;

namespace JtSQL.Linq {
    /// <summary>
    /// JtSQL作业
    /// </summary>
    public class Work {

        #region 成员

        /// <summary>
        /// jtsql代码
        /// </summary>
        private string _jtsql_code;

        /// <summary>
        /// js代码
        /// </summary>
        private string _js_code;

        /// <summary>
        /// 是否完成翻译
        /// </summary>
        private bool _is_parsed;

        /// <summary>
        /// 是否在运行
        /// </summary>
        private bool _is_running;

        #endregion

        #region 事件

        /// <summary>
        /// 翻译完成后
        /// </summary>
        public static event AfterParsingDelegate AfterParsing;

        /// <summary>
        /// SQL执行前
        /// </summary>
        public static event BeforeSQLExecutingDelegate BeforeSQLExecuting;

        /// <summary>
        /// SQL执行后
        /// </summary>
        public static event AfterSQLExecutedDelegate AfterSQLExecuted;

        #endregion

        #region 访问器

        /// <summary>
        /// jtsql代码
        /// </summary>
        public string JtsqlCode {
            get { return _jtsql_code; }
            set {
                if (_is_running)
                    throw new JtSQLChangingCodeDuringWorkRunningException();
                _jtsql_code = value;
                _is_parsed = false;
            }
        }

        /// <summary>
        /// js代码
        /// </summary>
        public string JsCode {
            get { return _js_code; }
            internal set {
                if (_is_running)
                    throw new JtSQLChangingCodeDuringWorkRunningException();
                _js_code = value;
                _is_parsed = true;
                // 调用翻译完成
                AfterParsing?.Invoke(value);
            }
        }

        /// <summary>
        /// 是否完成翻译
        /// </summary>
        public bool IsParsed { get { return _is_parsed; } }

        /// <summary>
        /// 是否在运行
        /// </summary>
        public bool IsRunning { get { return _is_running; } internal set { _is_running = value; } }

        #endregion

        #region 构造器

        /// <summary>
        /// 根据jtsql构造
        /// </summary>
        /// <param name="jtsql"></param>
        public Work(string jtsql) {
            _jtsql_code = jtsql;
            _js_code = "";
            _is_parsed = false;
            _is_running = false;
        }

        #endregion

    }
}
