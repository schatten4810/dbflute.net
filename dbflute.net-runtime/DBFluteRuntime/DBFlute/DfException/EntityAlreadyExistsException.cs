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

using SQLException = System.Data.Common.DbException

namespace DBFlute.DfException {

/**
 * The exception of when the entity already exists on the database.
 * @author jflute
 */
public class EntityAlreadyExistsException : SQLFailureException, EntityBusinessException {

    /**
     * Constructor.
     * @param msg The message of the exception. (NotNull)
     * @param cause SQLException. (NotNull)
     */
    public EntityAlreadyExistsException(String msg, SQLException cause) {
        super(msg, cause);
    }
}

}