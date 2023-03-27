
export class NeSerializer {

    private readonly typePropertyName: string = '__type__';
    private readonly outgoingTransitionsPropertyName = 'OutgoingTransitions';
    private readonly currentStateReportsPropertyName = 'CurrentStateReports';

    private rx_escapable = /[\\"\u0000-\u001f\u007f-\u009f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;

    private gap: any;
    private indent: any;
    private meta: any;
    private rep: any;

    public static stringify(value: any, replacer?: any, space?: any): any {
        const serializer = new NeSerializer();
        serializer.meta = {    // table of character substitutions
            '\b': '\\b',
            '\t': '\\t',
            '\n': '\\n',
            '\f': '\\f',
            '\r': '\\r',
            '\"': '\\\"',
            '\\': '\\\\'
        };
        return serializer.stringify(value, replacer, space);
    }

    public stringify(value: any, replacer?: any, space?: any) {

        // The stringify method takes a value and an optional replacer, and an optional
        // space parameter, and returns a JSON text. The replacer can be a function
        // that can replace values, or an array of strings that will select the keys.
        // A default replacer method can be provided. Use of the space parameter can
        // produce text that is more easily readable.

        let i;
        this.gap = '';
        this.indent = '';

        // If the space parameter is a number, make an indent string containing that
        // many spaces.

        if (typeof space === 'number') {
            for (i = 0; i < space; i += 1) {
                this.indent += ' ';
            }

            // If the space parameter is a string, it will be used as the indent string.

        } else if (typeof space === 'string') {
            this.indent = space;
        }

        // If there is a replacer, it must be a function or an array.
        // Otherwise, throw an error.

        this.rep = replacer;
        if (replacer && typeof replacer !== 'function' &&
            (typeof replacer !== 'object' ||
                typeof replacer.length !== 'number')) {
            throw new Error('JSON.stringify');
        }

        // Make a fake root object containing our value under the key of "".
        // Return the result of stringifying the value.

        return this.str('', { '': value });
    }


    private quote(string) {

        // If the string contains no control characters, no quote characters, and no
        // backslash characters, then we can safely slap some quotes around it.
        // Otherwise we must also replace the offending characters with safe escape
        // sequences.
        let that = this;
        this.rx_escapable.lastIndex = 0;
        return this.rx_escapable.test(string)
            ? '\"' + string.replace(this.rx_escapable, function (a) {
                let c = that.meta[a];
                return typeof c === 'string'
                    ? c
                    : '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
            }) + '\"'
            : '\"' + string + '\"';
    }

    private str(key: any, holder: any) {

        // Produce a string from holder[key].

        let index;          // The loop counter.
        let memberKey;          // The member key.
        let memberValue;          // The member value.
        let length;
        let mind = this.gap;
        let partial;
        let value = holder[key];

        // If the value has a toJSON method, call it to obtain a replacement value.

        if (value && typeof value === 'object' &&
            typeof value.toJSON === 'function') {
            if (value instanceof Date) {
                value = DateUtil.toLocalString(value);
            } else {
                value = value.toJSON(key);
            }
        }

        // If we were called with a replacer function, then call the replacer to
        // obtain a replacement value.

        if (typeof this.rep === 'function') {
            value = this.rep.call(holder, key, value);
        }

        // What happens next depends on the value's type.

        switch (typeof value) {
            case 'string':
                return this.quote(value);

            case 'number':

                // JSON numbers must be finite. Encode non-finite numbers as null.

                return isFinite(value)
                    ? String(value)
                    : 'null';

            case 'boolean':
                //case 'null':
                // If the value is a boolean or null, convert it to a string. Note:
                // typeof null does not produce "null". The case is included here in
                // the remote chance that this gets fixed someday.
                return String(value);

            // If the type is "object", we might be dealing with an object or an array or
            // null.


            case 'object':

                // Due to a specification blunder in ECMAScript, typeof null is "object",
                // so watch out for that case.
                if (!value) {
                    return 'null';
                }

                // Make an array to hold the partial results of stringifying this object value.

                this.gap += this.indent;
                partial = [];

                // Is the value an array?

                if (Object.prototype.toString.apply(value) === '[object Array]') {

                    // The value is an array. Stringify every element. Use null as a placeholder
                    // for non-JSON values.

                    length = value.length;
                    for (index = 0; index < length; index += 1) {
                        partial[index] = this.str(index, value) || 'null';
                    }

                    // Join all of the elements together, separated with commas, and wrap them in
                    // brackets.

                    memberValue = partial.length === 0
                        ? '[]'
                        : this.gap
                            ? '[\n' + this.gap + partial.join(',\n' + this.gap) + '\n' + mind + ']'
                            : '[' + partial.join(',') + ']';
                    this.gap = mind;

                    // şimdilik array türünü göndermeye gerek yok
                    // ne gibi bir durumda ihtiyaç olacak tespit yapılmalı A.Ş.: 2017.01.02
                    // memberValue = partial.length === 0 ? memberValue : `{\n "$type": "object[]",\n"$values": ${memberValue} }`;
                    return memberValue;
                }

                // If the replacer is an array, use it to select the members to be stringified.

                if (this.rep && typeof this.rep === 'object') {
                    length = this.rep.length;
                    for (index = 0; index < length; index += 1) {
                        if (typeof this.rep[index] === 'string') {
                            memberKey = this.rep[index];
                            memberValue = this.str(memberKey, value);
                            if (memberValue) {
                                partial.push(this.quote(memberKey) + (
                                    this.gap
                                        ? ': '
                                        : ':'
                                ) + memberValue);
                            }
                        }
                    }
                } else {

                    // Otherwise, iterate through all of the keys in the object.
                    if (typeof value[this.typePropertyName] === 'string') {
                        partial.push(`"$type": "${value[this.typePropertyName]}"`);
                    }

                    for (memberKey in value) {
                        if (memberKey !== this.typePropertyName
                        && memberKey !== this.outgoingTransitionsPropertyName
                    && memberKey !== this.currentStateReportsPropertyName) {
                            if (Object.prototype.hasOwnProperty.call(value, memberKey)) {
                                memberValue = this.str(memberKey, value);
                                if (memberValue) {
                                    partial.push(this.quote(memberKey) + (
                                        this.gap
                                            ? ': '
                                            : ':'
                                    ) + memberValue);
                                }
                            }
                        }
                    }
                }

                // Join all of the member texts together, separated with commas,
                // and wrap them in braces.

                memberValue = partial.length === 0
                    ? '{}'
                    : this.gap
                        ? '{\n' + this.gap + partial.join(',\n' + this.gap) + '\n' + mind + '}'
                        : '{' + partial.join(',') + '}';
                this.gap = mind;
                return memberValue;
        }
    }

}