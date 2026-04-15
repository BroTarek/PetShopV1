import React from 'react'

const SizeSelection = () => {
    return (
        <>

            <section>
                <h4 className="text-xs font-bold uppercase tracking-widest text-on-surface-variant mb-4">
                    Size</h4>
                <div className="space-y-3">
                    <label className="flex items-center gap-3 cursor-pointer group">
                        <input
                            className="w-5 h-5 rounded-md border-outline-variant text-primary focus:ring-primary"
                            type="checkbox" />
                        <span
                            className="text-sm font-medium group-hover:text-primary transition-colors">Small
                            (Under 20 lbs)</span>
                    </label>
                    <label className="flex items-center gap-3 cursor-pointer group">
                        <input
                            className="w-5 h-5 rounded-md border-outline-variant text-primary focus:ring-primary"
                            type="checkbox" />
                        <span
                            className="text-sm font-medium group-hover:text-primary transition-colors">Medium
                            (20-50 lbs)</span>
                    </label>
                    <label className="flex items-center gap-3 cursor-pointer group">
                        <input
                            className="w-5 h-5 rounded-md border-outline-variant text-primary focus:ring-primary"
                            type="checkbox" />
                        <span
                            className="text-sm font-medium group-hover:text-primary transition-colors">Large
                            (50+ lbs)</span>
                    </label>
                </div>
            </section>
        </>
    )
}

export default SizeSelection