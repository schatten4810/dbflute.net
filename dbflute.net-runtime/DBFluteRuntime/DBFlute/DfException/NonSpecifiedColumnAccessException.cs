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
 * The exception of when the non-specified column is accessed.
 * @author jflute
 * @since 1.1.0 (2014/10/20 Monday)
 */
public class NonSpecifiedColumnAccessException : RuntimeException {

    /**
     * Constructor.
     * @param msg The message of the exception. (NotNull)
     */
    public NonSpecifiedColumnAccessException(String msg) {
        super(msg);
    }

    /**
     * Constructor.
     * @param msg The message of the exception. (NotNull)
     * @param cause The cause of the exception. (NotNull)
     */
    public NonSpecifiedColumnAccessException(String msg, Throwable cause) {
        super(msg, cause);
    }
}

}