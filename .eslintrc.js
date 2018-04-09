module.exports = {
    "env": {
        "browser": true,
        "es6": true
    },
    "extends": "eslint:recommended",
    "parserOptions": {
        "sourceType": "module",
        "ecmaFeatures": {
            "experimentalObjectRestSpread": true,
            "jsx": true
        }
    },
    "rules": {
        "semi": [2, "always"],
        "react/jsx-uses-react": "error",
        "react/jsx-uses-vars": "error",
        "react/jsx-curly-spacing": [2, "always"],
        "mocha/no-exclusive-tests": "error",
        "object-curly-spacing": [2, "always"],
        "max-len": ["error", 120],
        "arrow-parens": ["error", "always"],
        "quotes": ["error", "double", { "allowTemplateLiterals": true }],
        "keyword-spacing": ["error", {"before": true, "after": true}],
        "indent": ["error", 4, {"SwitchCase": 1}],
        "comma-spacing": ["error", { "before": false, "after": true }],
        "key-spacing": ["error", { "beforeColon": false, "afterColon": true }],
        "no-trailing-spaces": ["error", { "skipBlankLines": true }],
        "arrow-spacing": "error",
        "no-duplicate-imports": "error",
        "prefer-const": "error",
        "prefer-template": "warn",
        "space-in-parens": ["error", "never"]
    },
    "plugins": [
        "react", "mocha"
    ]
};
