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
 * The exception of when the SQL failed to execute.
 * @author jflute
 */
public class SQLFailureException : RuntimeException {

    /** The cause of SQL failure. (NotNull) */
    protected readonly SQLException _sqlEx;

    /**
     * Constructor.
     * @param msg The message of the exception. (NotNull)
     * @param cause SQLException. (NotNull)
     */
    public SQLFailureException(String msg, SQLException cause) {
        super(msg, cause);
        _sqlEx = cause;
    }

    /**
     * Get the SQLException.
     * @return The instance of SQLException. (NotNull)
     */
    public SQLException getSQLException() {
        return _sqlEx;
    }
}

}