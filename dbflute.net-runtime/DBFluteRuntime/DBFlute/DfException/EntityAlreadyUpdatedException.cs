/*
 * Copyright 2014-2017 the original author or authors.
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *     http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
using System;
using DBFlute.JavaLike;
using DBFlute.JavaLike.Extensions;
using DBFlute.JavaLike.Lang;
using DBFlute.JavaLike.Time;
using DBFlute.JavaLike.Util;

using RuntimeException = System.ApplicationException;
using Throwable = System.Exception;

namespace DBFlute.DfException {

/**
 * The exception of when the entity has already been updated by other thread.
 * @author jflute
 */
public class EntityAlreadyUpdatedException : RuntimeException, EntityBusinessException {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    // legacy of S2Dao
    private Object _bean;
    private int _rows;

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    /**
     * Constructor.
     * @param bean The instance of entity. (NotNull)
     * @param rows The row count returned by update process. (basically zero)
     */
    public EntityAlreadyUpdatedException(Object bean, int rows)
        : base("The entity has already been updated: rows=" + rows + ", bean=" + bean, null)
    {
        _bean = bean;
        _rows = rows;
    }

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public Object getBean() {
        return _bean;
    }

    public int getRows() {
        return _rows;
    }
}

}