grammar Calculator;

/*
 * Parser Rules
 */
compileUnit : expression EOF;

expression
    : LPAREN expression RPAREN #ParenthesizedExpr
    | expression EXPONENT expression #ExponentialExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
    | expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
    | NUMBER #NumberExpr
    ;

/*
 * Lexer Rules
 */
NUMBER : [0-9]+ ('.' [0-9]+)?;
LPAREN : '(';
RPAREN : ')';
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
ADD : '+';
SUBTRACT : '-';
WS : [ \r\n\t]+ -> skip; 