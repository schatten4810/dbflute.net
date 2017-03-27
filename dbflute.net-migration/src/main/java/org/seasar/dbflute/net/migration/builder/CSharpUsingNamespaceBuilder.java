package org.seasar.dbflute.net.migration.builder;

import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.dbflute.util.DfCollectionUtil;
import org.dbflute.util.Srl;
import org.seasar.dbflute.net.migration.analyzer.JavaInfo;

/**
 * @author jflute
 */
public class CSharpUsingNamespaceBuilder extends CSharpBuilderBase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final List<String> _defaultUsingList;
    static {
        List<String> list = DfCollectionUtil.newArrayList();
        list.add("System");
        list.add("DBFlute.JavaLike");
        list.add("DBFlute.JavaLike.Extensions");
        list.add("DBFlute.JavaLike.Lang");
        list.add("DBFlute.JavaLike.Time");
        list.add("DBFlute.JavaLike.Util");
        _defaultUsingList = list;
    }

    protected static final Map<String, String> _toCapCamelWordMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("dbflute", "DBFlute");
        map.put("outsidesql", "OutsideSql");
        map.put("twowaysql", "TwoWaySql");
        map.put("system", "DfSystem");
        map.put("exception", "DfException");
        _toCapCamelWordMap = Collections.unmodifiableMap(map);
    }

    protected static final Map<String, String> _exceptionUsingMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("NumberFormatException", "NumberFormatException = System.FormatException");
        map.put("InstantiationException", "InstantiationException = System.TypeLoadException");
        map.put("IllegalAccessException", "IllegalAccessException = System.SecurityException");
        map.put("NoSuchMethodException", "NoSuchMethodException = System.MissingMethodException");
        map.put("RuntimeException", "RuntimeException = System.Exception");
        map.put("ClassCastException", "ClassCastException = System.InvalidCastException");
        map.put("Throwable", "Throwable = System.Exception");
        map.put("InterruptedException", "InterruptedException = System.Threading.ThreadInterruptedException");
        map.put("IndexOutOfBoundsException", "IndexOutOfBoundsException = System.IndexOutOfRangeException");
        map.put("InvocationTargetException", "InvocationTargetException = System.Reflection.TargetInvocationException");
        map.put("ClassNotFoundException", "ClassNotFoundException = System.TypeLoadException");
        map.put("Exception", "Exception = System.Exception");
        map.put("SecurityException", "SecurityException = System.Security.SecurityException");
        map.put("ParseException", "ParseException = System.FormatException");
        map.put("ExecutionException", "ExecutionException = System.Threading.ThreadStartException");
        map.put("SQLException", "SQLException = System.Data.Common.DbException");
        map.put("IOException", "IOException = System.IO.IOException");
        map.put("FileNotFoundException", "FileNotFoundException = System.IO.FileNotFoundException");
        map.put("UnsupportedEncodingException", "UnsupportedEncodingException = System.ArgumentException");
        _exceptionUsingMap = Collections.unmodifiableMap(map);
    }

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    public CSharpUsingNamespaceBuilder(JavaInfo javaInfo) {
        super(javaInfo);
    }

    // ===================================================================================
    //                                                                               Using
    //                                                                               =====
    public void buildUsingString(StringBuilder sb) {
        doBuildDefaultUsingClause(sb);
        doBuildMappingUsingClause(sb);
        doBuildMappingExceptionUsingClause(sb);
    }

    protected void doBuildDefaultUsingClause(StringBuilder sb) {
        List<String> defaultusinglist = _defaultUsingList;
        for (String defaultUsing : defaultusinglist) {
            sb.append("using ").append(defaultUsing).append(";").append(ln());
        }
    }

    protected void doBuildMappingUsingClause(StringBuilder sb) {
        Set<String> uniqueImportSet = new HashSet<String>();
        for (String importClass : _javaInfo.getImportList()) {
            String work = importClass;
            if (work.startsWith("java.")) {
                continue;
            }
            if (work.startsWith("org.seasar.dbflute.")) {
                work = replace(work, "org.seasar.dbflute.", "dbflute.");
            }
            if (work.startsWith("org.dbflute.")) {
                work = replace(work, "org.dbflute.", "dbflute.");
            }
            if (work.startsWith("dbflute.system")) {
                work = replace(work, "dbflute.system.", "dbflute.dfSystem.");
            }
            if (work.startsWith("dbflute.exception")) {
                work = replace(work, "dbflute.exception.", "dbflute.dfException.");
            }
            // remove class name and inner class name,
            // and convert to upper tokens
            work = toUpperDotString(removeUpperToken(work));
            if (uniqueImportSet.contains(work)) {
                continue;
            }
            uniqueImportSet.add(work);
            sb.append("using ").append(work).append(";").append(ln());
        }
    }

    protected void doBuildMappingExceptionUsingClause(StringBuilder sb) {
        Set<String> uniqueImportSet = new HashSet<String>();
        for (String exceptionClass : _javaInfo.getCatchExceptionList()) {
            String work = exceptionClass;
            if (uniqueImportSet.contains(work)) {
                continue;
            }
            uniqueImportSet.add(work);
            if (!_exceptionUsingMap.containsKey(work)) {
                continue;
            }
            sb.append("using ").append(_exceptionUsingMap.get(work)).append(";").append(ln());
        }
    }

    // ===================================================================================
    //                                                                           Namespace
    //                                                                           =========
    public void buildNamespaceClause(StringBuilder sb) {
        String packageName = _javaInfo.getPackageName();
        sb.append("namespace ").append(toUpperDotString(packageName)).append(" {").append(ln());
    }

    protected String removeUpperToken(String dotString) {
        List<String> tokenList = splitList(dotString, ".");
        StringBuilder sb = new StringBuilder();
        for (String token : tokenList) {
            if (Srl.isInitUpperCase(token)) {
                continue;
            }
            if (sb.length() > 0) {
                sb.append(".");
            }
            sb.append(token);
        }
        return sb.toString();
    }

    protected String toUpperDotString(String dotString) {
        List<String> tokenList = splitList(dotString, ".");
        StringBuilder sb = new StringBuilder();
        for (String token : tokenList) {
            if (sb.length() > 0) {
                sb.append(".");
            }
            sb.append(initCap(replaceBy(token, _toCapCamelWordMap)));
        }
        return sb.toString();
    }
}
