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

namespace DBFlute.DfException {

/**
 * The exception of when the entity has already been updated by other thread in batch update.
 * @author jflute
 */
public class BatchEntityAlreadyUpdatedException : EntityAlreadyUpdatedException {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    protected Integer _batchUpdateCount;

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    /**
     * Constructor.
     * @param bean The instance of entity. (NotNull)
     * @param rows The row count returned by update process. (basically zero)
     * @param batchUpdateCount Batch update count(Total).
     */
    public BatchEntityAlreadyUpdatedException(Object bean, int rows, Integer batchUpdateCount) {
        super(bean, rows);
        _batchUpdateCount = batchUpdateCount;
    }

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public Integer getBatchUpdateCount() {
        return _batchUpdateCount;
    }
}

}